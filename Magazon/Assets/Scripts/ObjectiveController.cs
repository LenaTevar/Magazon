using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Parcel")
        {
            ParcelController parcel = other.GetComponent<ParcelController>();

            parcel.getLucky();
            
            Destroy(gameObject);
        }
    }
}
