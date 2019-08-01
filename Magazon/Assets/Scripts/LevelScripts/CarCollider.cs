using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollider : MonoBehaviour
{
    public AudioSource source;
    public string name; 
    void OnTriggerEnter(Collider other)
    {
        
        source.Play();
    }
}
