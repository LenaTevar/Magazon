using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveComponent : MonoBehaviour
{   void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Parcel"))
        {
            other.GetComponent<ParcelController>().rollForLuck();
            Destroy(gameObject);
        }
    }
}

