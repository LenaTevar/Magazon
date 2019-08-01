using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVanController : MonoBehaviour
{

    public AudioSource motorSource;
    public AudioSource hornSource;
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
        updatePitch();
        if (Input.GetKeyDown("r"))
        {
            hornSource.Play();

        }
    }

    private void updateSpeed()
    {
        speed = van.GetComponent<Rigidbody>().velocity.magnitude;
    }

    private void updatePitch()
    {
        updateSpeed();
        if (speed < 0)
        {
            pitch = 1;
        }
        else
        {
            pitch = 1 + (speed / modifier);
        }

        motorSource.pitch = pitch;
    }


    
}


