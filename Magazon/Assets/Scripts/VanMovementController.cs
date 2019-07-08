using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanMovementController : MonoBehaviour
{
    [Header("Center of Mass")]
    [Tooltip("Tweak the center of mass of the van so it does not flip over.")]
    public Vector3 centerOfMass;
    [Header("Movement Setup")]
    [Tooltip("Information about each individual axle.")]
    public List<AxleInfo> axleInfos;
    [Tooltip("Maximum torque the motor can apply to wheel.")]
    public float maxMotorTorque;
    [Tooltip("Maximum steer angle the wheel can have.")]
    public float maxSteeringAngle;

    public float maxMotorBrake=0f;


    [Header("Parcels Setup")]
    public GameObject parcel;
    public Transform parcelSpawn;
    public float fireRate;
    private float nextFire;
    
    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
    }


    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            shoot();
        }
    }

 

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space) == true)
        {
            maxMotorBrake = 300;
        } else
        {
            maxMotorBrake = 0;
        }

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
                
            } else if (!axleInfo.motor)
            {
                axleInfo.leftWheel.brakeTorque = maxMotorBrake;
                axleInfo.rightWheel.brakeTorque = maxMotorBrake;
            }
            ApplyLocalPositionToVisuals(axleInfo);
        }

        

    }
    public void ApplyLocalPositionToVisuals(AxleInfo axleInfo)
    {       
        moveOneVisualWheel(axleInfo.leftWheel, axleInfo.leftVisual);
        moveOneVisualWheel(axleInfo.rightWheel, axleInfo.rightVisual);
    }


    private void moveOneVisualWheel(WheelCollider collider, GameObject visual) {
        Vector3 colliderPosition;
        Quaternion colliderRotation;

        collider.GetWorldPose(out colliderPosition, out colliderRotation);
        colliderRotation = colliderRotation * Quaternion.Euler(new Vector3(0, 90, 0));

        visual.transform.position = colliderPosition;
        visual.transform.rotation = colliderRotation;        
    }

    private void shoot()
    {
        if (Input.GetKey("e"))
        {
            nextFire = Time.time + fireRate;
            Instantiate(parcel, parcelSpawn.position, parcelSpawn.rotation);
        }
        else if (Input.GetKey("q"))
        {
            nextFire = Time.time + fireRate;
            Instantiate(parcel, parcelSpawn.position, parcelSpawn.rotation);
        }
    }
}

[System.Serializable]
public class AxleInfo
{
    [Header("Wheels Colliders")]
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    [Header ("Wheels visuals")]
    public GameObject leftVisual;
    public GameObject rightVisual;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}

