using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanRadar : MonoBehaviour
{
    public Transform objective;
    /*
     Method: OnTriggerEnter
     Saves the transform of the collider tagged as Objective
     to be  used by Robust Parcels. 
         */
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Objective"))
        {         
            objective = other.gameObject.transform;            
        }

        /*else
        {          
            objective = null;
        }*/
    }
}
