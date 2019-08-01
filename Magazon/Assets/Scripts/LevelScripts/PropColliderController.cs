using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropColliderController : MonoBehaviour
{
    public Rigidbody prop;
    public AudioSource source;
    public string name;
    public float speedlimit = 0.001f;
    private float speed;
    private bool flagged = false;


    void OnTriggerStay(Collider other)
    {
        speed = prop.velocity.magnitude;
      
        
        if (speed > speedlimit && !flagged)
        {
            flagged = true;
            source.Play();
            print(name);
        } else if (speed < speedlimit)
        {
            source.Stop();
            flagged = false;
        }
    }

}
