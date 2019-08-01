using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobustParcelController : ParcelController
{
    public GameObject deliverAnimation;
    private Transform objectiveCoord = null;
    void Start()
    {

        parcelSetup();
        gameObjectsSetup();
      
    }

    new public void parcelSetup()
    {
        int successPoints = 10;
        int brokenPoints = 1;
        float delayToDestroy = 5f;
        float probabilityOfFail = 0.9f;
        parcelSpecs = new Parcel(successPoints, brokenPoints, delayToDestroy, probabilityOfFail);
    }

    new public void gameObjectsSetup()
    {
        base.levelController = FindObjectOfType<LevelController>();
        objectiveCoord = GameObject.FindGameObjectWithTag("Player").transform.GetComponentInChildren<VanRadar>().objective;

        base.levelController.toggleKeyboard();
        deliveringAnimations();
        StartCoroutine(destroyLostParcel());
    }

    void deliveringAnimations()
    {
        GameObject deliverAni = Instantiate(deliverAnimation, transform.position, transform.rotation);
        deliverAni.transform.parent = gameObject.transform;        
    }
    
    void Update()
    {
        if(objectiveCoord != null)
        {
            moveTowardsObjective();    
            print("Robust Parcel: Objective found");
        }
       
    }

    void moveTowardsObjective()
    {
        float step = base.speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, objectiveCoord.position, step);
    }

    void OnDestroy()
    {
        base.levelController.toggleKeyboard();
    }
}