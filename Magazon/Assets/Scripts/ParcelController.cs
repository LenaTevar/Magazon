using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcelController : MonoBehaviour
{
    [Header("Parcel Shooter Setup")]
    public float speed; 
    [Header("Success delivery")]
    [Tooltip("Prefab with an explosion for succesfull deliveries.")]
    public GameObject Success;
    public string successSound = "good";
    [Header("Failed delivery")]
    [Tooltip("Prefab with an explosion for broken/lost deliveries.")]
    public GameObject Failure;
    public string failureSound = "fail";
    [Header("Parcel lost")]
    public string lostSound = "lost";

    private int brokenPoints = 1;
    private int successPoints = 5;
    private int lostPoints = -1;

    private float probabilityOfFail = 0.3f;
    [HideInInspector]
    public LevelController levelController;
 
    void Start()
    {
        //Children will change start method.
        basicSetUp();

       
    }

    public void basicSetUp()
    {
        levelController = FindObjectOfType<LevelController>();

        GetComponent<Rigidbody>().velocity = transform.right * speed;
        StartCoroutine(delayedDestroy());

        if (lostPoints > 0)
            Debug.Log("Lost points must be negative");
        gameObject.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void rollForLuck()
    {
        if (getsDelivered())
        {
            deliverWith(Success, successPoints, successSound);
        }
        else
        {
            deliverWith(Failure, brokenPoints, failureSound);
        }
    }

    public void deliverWith(GameObject deliverType, int points, string soundName)
    {        
        Destroy(gameObject);
        instantiateAnimation(deliverType);
        levelController.updateArrivedParcels(points);

        levelController.playSoundEffect(soundName);
        Debug.Log("Parcel Controller play sound effect " + soundName);
    }
   

    public IEnumerator delayedDestroy()
    {
        yield return new WaitForSeconds(5);
        deliverWith(Failure, lostPoints, lostSound);     
        
    }

    public bool getsDelivered()
    {
        if (Random.value > probabilityOfFail)
            return false;
        return true;
    }

    private void instantiateAnimation(GameObject deliverType)
    {
        GameObject temp = Instantiate(deliverType, transform.position, transform.rotation);
        Destroy(temp, 1);
    }

    public void setPoints(float probability, int SuccessPoints, int FailurePoints)
    {
        probabilityOfFail = probability;
        successPoints = SuccessPoints;
        brokenPoints = FailurePoints;
    }

 
   

}
