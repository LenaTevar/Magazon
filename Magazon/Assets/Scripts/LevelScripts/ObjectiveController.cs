using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{   void OnTriggerEnter(Collider other)
    {
        print("Objective controller other tag: " + other.tag);
        if (other.tag.Contains("Parcel"))
        {
            other.GetComponent<ParcelController>().rollForLuck();
            Destroy(gameObject);
        }
    }
}

