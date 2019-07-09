using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Parcel")
        {
            ParcelShotter parcel = other.GetComponent<ParcelShotter>();

            parcel.getLucky();
            
            Destroy(gameObject);
        }
    }
}
