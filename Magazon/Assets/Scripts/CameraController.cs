using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f; //high => faster 
    public float rotationSpeed = 5f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate() //after update
    {
              

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothDampPosition = Vector3.SmoothDamp(
            transform.position, 
            desiredPosition, 
            ref velocity, 
            smoothSpeed);


        /*
        ///// Don't use: adds jitter to the camera
        transform.rotation = target.rotation;


        ///////////not working

        Quaternion goalRotation = Quaternion.LookRotation(smoothDampPosition-transform.position, target.transform.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, goalRotation, rotationSpeed * 1f);

        /////////////// Quaternions
        */    
        Quaternion targetRotation = target.rotation;
        Vector3 changeV3;
        float rotY = (float) targetRotation.eulerAngles.y;
        rotY = rotY * 180  / (float)  Math.PI;
        changeV3.x = (float) Math.Cos(rotY) * 10;
        changeV3.z = (float) Math.Sin(rotY)*10;
        changeV3.y = 0;
        //changeV3.x = 0;
        Vector3 currentCameraPosition = target.position;

        currentCameraPosition = currentCameraPosition - changeV3;
        currentCameraPosition.y = 10;
//        currentCameraPosition.z = currentCameraPosition - changeZ;
        transform.position = currentCameraPosition;
        transform.LookAt(target);

         

        /*

        transform.position = smoothDampPosition;

        Quaternion desiredRotation = target.rotation;

        transform.rotation = desiredRotation;

        //transform.LookAt(target.position);
        //transform.LookAt(target);
        */
    }
}

//https://docs.unity3d.com/ScriptReference/Vector3.SmoothDamp.html