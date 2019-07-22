using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanRadar : MonoBehaviour
{
    public Transform objective;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Objective"))
        {
            objective = other.gameObject.transform;
            
        } else
        {
            objective = null;
        }
    }
}
