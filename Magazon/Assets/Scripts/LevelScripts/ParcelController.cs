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
 

    [HideInInspector]
    public Parcel parcelSpecs;

    [HideInInspector]
    public LevelController levelController;
 
    void Start()
    {
        parcelSetup();
        gameObjectsSetup();
    }

    public void parcelSetup()
    {
        int successPoints = 5;
        int brokenPoints = 1;
        float delayToDestroy = 5f;
        float probabilityOfFail = 0.3f;
        parcelSpecs = new Parcel(successPoints, brokenPoints, delayToDestroy, probabilityOfFail);
    }
    public void gameObjectsSetup()
    {
        levelController = FindObjectOfType<LevelController>();

        GetComponent<Rigidbody>().velocity = transform.right * speed;
        StartCoroutine(destroyLostParcel());
    }

    public void rollForLuck()
    {
        if (parcelSpecs.getsDelivered())
        {
            deliverWith(Success, parcelSpecs.success, successSound);
        }
        else
        {
            deliverWith(Failure, parcelSpecs.broken, failureSound);
        }
    }

    public void deliverWith(GameObject deliverType, int points, string soundName)
    {        
        Destroy(gameObject);
        instantiateAnimation(deliverType);
        levelController.updateArrivedParcels(points);

        levelController.playSoundEffect(soundName);
    }
   

    public IEnumerator destroyLostParcel()
    {
        yield return new WaitForSeconds(5);
        deliverWith(Failure, parcelSpecs.lost, lostSound);     
        
    }

    private void instantiateAnimation(GameObject deliverType)
    {
        GameObject temp = Instantiate(deliverType, transform.position, transform.rotation);
        Destroy(temp, 1);
    }

}

