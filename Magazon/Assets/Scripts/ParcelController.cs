using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcelController : MonoBehaviour
{
    [Header("Parcel Shooter Setup")]
    public float speed;
    [Tooltip("The parcel will not break.")]
    private bool Survives;
    [Tooltip("Prefab with an explosion for succesfull deliveries.")]
    public GameObject Success;
    [Tooltip("Prefab with an explosion for broken/lost deliveries.")]
    public GameObject Failure;

    private int brokenPoints = 1;
    private int successPoints = 5;
    private int failPoints = -1;

    private float probabilityOfFail = 0.3f;
    public LevelController levelController;
 
    void Start()
    {
        //Children will change start method.
        basicSetUp();

       
    }

    public void basicSetUp()
    {
        levelController = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();

        GetComponent<Rigidbody>().velocity = transform.right * speed;
        StartCoroutine(delayedDestroy());

        if (failPoints > 0)
            Debug.Log("Broken points must be negative");
        gameObject.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void rollForLuck()
    {
        if (getsDelivered())
        {
            deliverWith(Success, successPoints);
        }
        else
        {
            deliverWith(Failure, brokenPoints);
        }
    }

    public void deliverWith(GameObject deliverType, int points)
    {        
        Destroy(gameObject);
        instantiateAnimation(deliverType);
        levelController.updateArrivedParcels(points);
    }
   

    public IEnumerator delayedDestroy()
    {
        yield return new WaitForSeconds(5);
        deliverWith(Failure, failPoints);     
        
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

/*
 
     using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcelController : MonoBehaviour
{
    [Header("Parcel Shooter Setup")]
    public float speed;
    [Tooltip("The parcel will not break.")]
    private bool Survives;
    [Tooltip("Prefab with an explosion for succesfull deliveries.")]
    public GameObject Success;
    [Tooltip("Prefab with an explosion for broken/lost deliveries.")]
    public GameObject Failure;

    private int brokenPoints = 1;
    private int successPoints = 5;
    private int failPoints = -1;

    private float probabilityOfFail = 0.3f;
    private GUIController GUIController;
 
    void Start()
    {
        //Children will change start method.
        basicSetUp();
    }

    public void basicSetUp()
    {
        setUpGUIController();

        GetComponent<Rigidbody>().velocity = transform.right * speed;
        StartCoroutine(delayedDestroy());

    }

    public void rollForLuck()
    {
        if (getsDelivered())
        {
            deliverWith(Success, successPoints);
        }
        else
        {
            deliverWith(Failure, brokenPoints);
        }
    }

    public void deliverWith(GameObject deliverType, int points)
    {        
        Destroy(gameObject);
        instantiateAnimation(deliverType);
        notifyGUIController(points);
        enableInput();
    }
   

    IEnumerator delayedDestroy()
    {
        yield return new WaitForSeconds(5);
        deliverWith(Failure, failPoints);     
        
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

    public void enableInput()
    {
        if(!GameController.IsInputEnabled)
            GameController.IsInputEnabled = true;
    }
    private void setUpGUIController()
    {
        GameObject tmp = GameObject.FindGameObjectWithTag("GUIController");
        GUIController = tmp.GetComponent<GUIController>();
        GUIController.UpdateScore(0);
    }

    private void notifyGUIController(int points)
    {
        GUIController.UpdateScore(points);
    }
}

     */
