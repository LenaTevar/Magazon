using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Rigidbody
 Angular Drag = 0
 DONT use gravity
     */
public class RobustParcelController : ParcelController
{
    public GameObject deliverAnimation;
    private float robustProbability = 0.9f;
    private int robustBrokenPoints = 1;
    private int robustSuccesPoints = 10;
    void Start()
    {
        GameController.IsInputEnabled = false;
        Debug.Log("ROBUST CONTROLLER - INPUT FALSE");
        setUpRobust();
        base.setUp();
        delivering();
    }

    private void delivering()
    {
        GameObject deliverAni = Instantiate(deliverAnimation, transform.position, transform.rotation);
        deliverAni.transform.parent = gameObject.transform;
        
    }


    private void setUpRobust()
    {
        base.setProbabilityOfFail(robustProbability);
        base.setPoints(robustSuccesPoints, robustBrokenPoints);
    }
}
