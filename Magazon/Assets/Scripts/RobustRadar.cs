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
        parentController.setUpTransform(other.transform);
    }
}
