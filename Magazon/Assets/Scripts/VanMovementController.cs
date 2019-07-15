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

    public float speed;

    public GameObject levelControllerHolder;
    private LevelController levelController;

    private bool vanIsStationary = false;

    void Start()
    {
        levelController = levelControllerHolder.GetComponent<LevelController>();

        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
    }
    public void FixedUpdate()
    {
        checkIfStatonaryAndMove();
    }
    public void checkIfStatonaryAndMove()
    {
        if (levelController.isKeyboardEnabled())
        {
            vanIsStationary = false;          
            
        } else
        {
            vanIsStationary = true;
        }

        moveVan();
    }
    public void moveVan()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        speed = GetComponent<Rigidbody>().velocity.magnitude;

        BrakesCheck();

        foreach (AxleInfo axleInfo in axleInfos)
        {
            ApplyMotorSteeringOrBrake(axleInfo, steering, motor);
            ApplyMovementToVisualWheels(axleInfo);
        }
    }


    private void BrakesCheck()
    {
        if (vanIsStationary || Input.GetKey(KeyCode.Space))
        {
            maxMotorBrake = 300;
        }
        else
        {
            maxMotorBrake = 0; 
        }
    }

    
    private void ApplyMotorSteeringOrBrake(AxleInfo axleInfo, float steering, float motor)
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

        }
        else 
        {
            axleInfo.leftWheel.brakeTorque = maxMotorBrake;
            axleInfo.rightWheel.brakeTorque = maxMotorBrake;
        }
        
    }
    private void ApplyMovementToVisualWheels(AxleInfo axleInfo)
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
    [Tooltip("Apply if Axle has motor.")]
    public bool motor; // is this wheel attached to motor?
    [Tooltip("Apply if Axle moves when turning.")]
    public bool steering; // does this wheel apply steer angle?
}

/*
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

    private bool vanIsStationary = false;

    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
    }
    public void FixedUpdate()
    {
        checkIfStatonaryAndMove();
    }
    public void checkIfStatonaryAndMove()
    {
        if (GameController.IsInputEnabled)
        {
            vanIsStationary = false;          
            
        } else
        {
            vanIsStationary = true;
        }

        moveVan();
    }
    public void moveVan()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        BrakesCheck();

        foreach (AxleInfo axleInfo in axleInfos)
        {
            ApplyMotorSteeringOrBrake(axleInfo, steering, motor);
            ApplyMovementToVisualWheels(axleInfo);
        }
    }


    private void BrakesCheck()
    {
        if (vanIsStationary)
        {
            maxMotorBrake = 300;
        }
        else
        {
        _ = Input.GetKey(KeyCode.Space) ? maxMotorBrake = 300 : maxMotorBrake = 0; 
        }
    }

    
    private void ApplyMotorSteeringOrBrake(AxleInfo axleInfo, float steering, float motor)
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

        }
        else 
        {
            axleInfo.leftWheel.brakeTorque = maxMotorBrake;
            axleInfo.rightWheel.brakeTorque = maxMotorBrake;
        }
        
    }
    private void ApplyMovementToVisualWheels(AxleInfo axleInfo)
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
    [Tooltip("Apply if Axle has motor.")]
    public bool motor; // is this wheel attached to motor?
    [Tooltip("Apply if Axle moves when turning.")]
    public bool steering; // does this wheel apply steer angle?
}


     */
