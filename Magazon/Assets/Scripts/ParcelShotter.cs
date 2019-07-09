using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcelShotter : MonoBehaviour
{
    [Header("Parcel Shooter Setup")]
    public float speed;
    [Tooltip("The parcel will not break.")]
    public bool Survives;
    [Tooltip("Prefab with an explosion for succesfull deliveries.")]
    public GameObject DestroySucceed;
    [Tooltip("Prefab with an explosion for broken/lost deliveries.")]
    public GameObject ExplosionDrama;
    private bool delivered = false;

    void Start ()
    {
        GetComponent<Rigidbody>().velocity = transform.right * speed;
        if (!delivered)
            StartCoroutine(simpleDestroy());
    }

    public void getLucky()
    {
        delivered = true;
        if (Survives)
            destroySucceed();
        else
            destroyWithDrama();
    }

    private void destroySucceed() {        
        delivered = true;
        Destroy(gameObject);
        DestroySucceed = Instantiate(DestroySucceed, transform.position, transform.rotation);
        Destroy(DestroySucceed, 1);
        
    }

    private void destroyWithDrama() {
        Destroy(gameObject);
        ExplosionDrama = Instantiate(ExplosionDrama, transform.position, transform.rotation);
        Destroy(ExplosionDrama, 1);
    }

    IEnumerator simpleDestroy()
    {
        yield return new WaitForSeconds(5);
        GameObject simple = Instantiate(ExplosionDrama, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(simple, 1);

    }
}
