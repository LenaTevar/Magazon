using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcelShotter : MonoBehaviour
{
    public float speed;


    void Start ()
    {
        GetComponent<Rigidbody>().velocity = transform.right * speed;
        Destroy(gameObject, 5);
       
    }

    private void getLucky()
    {

    }

}
