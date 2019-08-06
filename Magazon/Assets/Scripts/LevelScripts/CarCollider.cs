using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollider : MonoBehaviour
{
    public AudioSource source;
    void OnTriggerEnter(Collider other)
    {        
        source.Play();
    }
}
