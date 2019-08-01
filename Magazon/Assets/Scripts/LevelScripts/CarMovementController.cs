using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementController : MonoBehaviour
{
    public GameObject path;
    public float nodeDistance = 0.05f;
    public float maxSteerAngle = 30f;
    public float motorTorque = 10f;
    public float maxSpeed = 100f;
    public float currentSpeed;

    public List<AxleInfo> axleInfos;

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
        
        float newSteer = calculateNewSteer();

        foreach (AxleInfo axle in axleInfos)
        {

            moveSteering(axle, newSteer);
            ApplyMovementToVisualWheels(axle);


        }

        CheckPosition(nodes[currentNode]);

    }

   
    private void moveSteering(AxleInfo axle, float newSteer)
    {
        if (axle.steering)
        {
            axle.rightWheel.steerAngle = newSteer;
            axle.leftWheel.steerAngle = newSteer;

            checkMaxSpeed(axle);
        }
    }

    private void checkMaxSpeed(AxleInfo axle)
    {
        currentSpeed = 2 * Mathf.PI * axle.rightWheel.radius * axle.rightWheel.rpm * 60 / 1000;

        if (currentSpeed > maxSpeed)
        {
            axle.rightWheel.motorTorque = brake;
            axle.leftWheel.motorTorque = brake;
        }
        else
        {
            axle.rightWheel.motorTorque = motorTorque;
            axle.leftWheel.motorTorque = motorTorque;
        }
    }
    

    private float calculateNewSteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);

        relativeVector /= relativeVector.magnitude;
        return (relativeVector.x / relativeVector.magnitude) * maxSteerAngle; 
    }
   
    private void CheckPosition(Transform node)
    {
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < nodeDistance)
        {
            moveNextNode();
        }
    }

    private void  moveNextNode()
    {
        if (currentNode >= nodes.Count-1)
                currentNode = 0;
            else
                currentNode++;
    }
   

    private void ApplyMovementToVisualWheels(AxleInfo axleInfo)
    {
        moveOneVisualWheel(axleInfo.leftWheel, axleInfo.leftVisual);
        moveOneVisualWheel(axleInfo.rightWheel, axleInfo.rightVisual);
    }

    private void moveOneVisualWheel(WheelCollider collider, GameObject visual)
    {
        Vector3 colliderPosition;
        Quaternion colliderRotation;

        collider.GetWorldPose(out colliderPosition, out colliderRotation);
        colliderRotation = colliderRotation * Quaternion.Euler(new Vector3(90, 0, 0));

        visual.transform.position = colliderPosition;
        visual.transform.rotation = colliderRotation;
    }
}
