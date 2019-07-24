using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementController : MonoBehaviour
{
    public GameObject path;
    public float nodeDistance = 0.05f;
    public WheelCollider wheelLeftFront;
    public WheelCollider wheelRightFront;
    public float maxSteerAngle = 30f;
    public float motorTorque = 10f;
    public float maxSpeed = 100f;
    public float currentSpeed;


    private List<Transform> nodes;
    private int currentNode = 0;
    private float brake = 0f;
    void Start()
    {
        nodes = path.GetComponent<PathController>().getNodes();
    }

    // Update is called once per frame
    void FixedUpdate()
    {        
        ApplySteer();
        AutoDrive();
        CheckPosition(nodes[currentNode]);
    }
    private void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);

        relativeVector /= relativeVector.magnitude;

        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;

        wheelLeftFront.steerAngle = newSteer;
        wheelRightFront.steerAngle = newSteer;

    }
    private void AutoDrive()
    {
        if (isMaxSpeed())
        {
            setMotorTorque(brake);
        }
        else
        {
            setMotorTorque(motorTorque);
        }
        
    }

    private void setMotorTorque(float torque)
    {
        wheelLeftFront.motorTorque = torque;
        wheelRightFront.motorTorque = torque;
    }

    private void CheckPosition(Transform node)
    {
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < nodeDistance)
        {
            if (currentNode >= nodes.Count-1)
            {
                currentNode = 0;
            } else
            {
                currentNode++;
            }
        }
    }

    private bool isMaxSpeed()
    {
        currentSpeed = 2 * Mathf.PI * wheelLeftFront.radius * wheelLeftFront.rpm * 60 / 1000;

        if(currentSpeed > maxSpeed)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
