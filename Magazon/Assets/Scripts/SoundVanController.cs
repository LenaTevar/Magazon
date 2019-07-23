using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVanController : MonoBehaviour
{

    public AudioSource source;
    private float speed;
    private float pitch;
    private float modifier = 30;

    private GameObject van;

    
    void Start()
    {
        van = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        updateSpeed();

        if (speed < 0)
        {
            pitch = 1;
        } else
        {            
            pitch = 1 + (speed / modifier);
        }

        source.pitch = pitch;

    }

    private void updateSpeed()
    {
        speed = van.GetComponent<Rigidbody>().velocity.magnitude;
    }

    
}
