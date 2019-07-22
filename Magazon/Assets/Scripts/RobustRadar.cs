using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobustRadar : MonoBehaviour
{
   
    private RobustParcelController parentController;
    void Start()
    {
       
        parentController = gameObject.transform.parent.GetComponent<RobustParcelController>();
    }
    void OnTriggerEnter(Collider other)
    {
        /*
        Debug.Log(">>RADAR: Something collided!");
        if(other.tag == "Objective")
        {
            Debug.Log(">>RADAR: Objective Collider! Sending transform to parent. ");
            Transform go = other.gameObject.transform;
            parentController.setUpTransform(go);
            
        }*/
    }
}
