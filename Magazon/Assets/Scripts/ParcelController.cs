using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcelController : MonoBehaviour
{
    [Header("Parcel Shooter Setup")]
    public float speed;
    [Tooltip("The parcel will not break.")]
    private bool Survives;
    [Tooltip("Prefab with an explosion for succesfull deliveries.")]
    public GameObject DestroySucceed;
    [Tooltip("Prefab with an explosion for broken/lost deliveries.")]
    public GameObject ExplosionDrama;

    private int brokenPoints = 1;
    private int successPoints = 5;

    private float probabilityOfFail = 0.3f;
    /*
     Children may change start method. 
         */
    void Start()
    {
        setUp();
    }

    public void setUp()
    {
        GetComponent<Rigidbody>().velocity = transform.right * speed;
        StartCoroutine(simpleDestroy());
    }

    public void rollForLuck()
    {
        Debug.Log("ROLLING FOR LUCK");
        if (getsDelivered())
        {
            deliverWith(DestroySucceed);
            Debug.Log("/t estroy succeed");
        }
        else
        {
            deliverWith(ExplosionDrama);
            Debug.Log("/t drama");
        }

       
    }

    public void deliverWith(GameObject deliverType)
    {        
        Destroy(gameObject);
        GameObject temp = Instantiate(deliverType, transform.position, transform.rotation);
        Destroy(temp, 1);
        enableInput();
    }
   

    IEnumerator simpleDestroy()
    {
        yield return new WaitForSeconds(5);
        GameObject simple = Instantiate(ExplosionDrama, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(simple, 1);
        enableInput();
    }

    public bool getsDelivered()
    {
        if (Random.value > probabilityOfFail)
            return false;
        return true;
    }

    public void setProbabilityOfFail(float probability)
    {
        probabilityOfFail = probability;
    }

    public void setPoints(int good, int broken)
    {
        successPoints = good;
        brokenPoints = broken;
    }

    public void enableInput()
    {
        GameController.IsInputEnabled = true;
        Debug.Log("PARCEL CONTROLLER - INPUT TRUE");
    }
}
