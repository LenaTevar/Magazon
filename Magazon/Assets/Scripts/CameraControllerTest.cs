using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerTest : MonoBehaviour
{
    [Header("Player Car")]
    public Transform target;
    [Header("Camera Position")]
    public float distance = 10.0f;
    public float height = 5.0f;
    [Header("Damping speeds")]

    [Tooltip("Speed the camera follows the car.")]
    public float damping = 5.0f;
    public float rotationDamping = 10.0f;

    [Header("Test functionalities")]
    public bool smoothRotation = true;
    [Tooltip("Camera behind of in front of car")]
    public bool followBehind = true;
    //TODO: If car reverse -> followBehind false

    private Vector3 wantedPosition;

    void FixedUpdate()
    {       

        if (followBehind)
        {
            wantedPosition = target.TransformPoint(0, height, -distance);
        } else
        {
            wantedPosition = target.TransformPoint(0, height, distance);
        }

        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

        Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);

        transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);

       // if (smoothRotation)
       // {

            // }
        //else transform.LookAt(target, target.up);
    }

  
}
//http://wiki.unity3d.com/index.php/SmoothFollow2