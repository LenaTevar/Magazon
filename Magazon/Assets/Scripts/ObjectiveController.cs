using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{   void OnTriggerEnter(Collider other)
    {
        Debug.Log(">> Objective Collider Activate");
        if (other.tag.Contains("Parcel"))
        {
            Debug.Log(">> Objective Collider found Parcel: " + other.tag);

            other.GetComponent<ParcelController>().rollForLuck();
            Destroy(gameObject);
        }
    }
}

