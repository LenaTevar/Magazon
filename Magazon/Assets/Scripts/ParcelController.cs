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
    private bool hasBeenDelivered = false;

    private float probabilityOfFail = 0.8f;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.right * speed;
        if (!hasBeenDelivered)
            StartCoroutine(simpleDestroy());
    }

    public void getLucky()
    {
        hasBeenDelivered = true;

        Survives = randomProb(probabilityOfFail);

        if (Survives)
            destroySucceed();
        else
            destroyWithDrama();
    }

    private void destroySucceed()
    {
        Destroy(gameObject);
        DestroySucceed = Instantiate(DestroySucceed, transform.position, transform.rotation);
        Destroy(DestroySucceed, 1);

    }

    private void destroyWithDrama()
    {
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

    private bool randomProb(float failChance)
    {
        if (Random.value > failChance)
            return false;
        return true;
    }
}
