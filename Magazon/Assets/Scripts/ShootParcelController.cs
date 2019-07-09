using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootParcelController : MonoBehaviour
{
    [Header("Shooting Parcel")]
    public GameObject fragileParcel;
    public GameObject robustParcel;
    [Tooltip("Location of the spawn for parcels.")]
    public Transform parcelSpawn;
    [Tooltip("Time between shoots.")]
    public float fireRate;
    public float totalParcels = 5;

    private float nextFire = 0;
    void Update()
    {
        if(nextFire == 0 || Time.time > nextFire )
        {
            nextFire = Time.time + fireRate;
            if (hasAmmo())
                fireParcel();
        }
    }
      
    private void fireParcel()
    {      
        if (Input.GetKey("e"))
        {
            setAndInstantiateParcel(fragileParcel);
        }
        else if (Input.GetKey("q"))
        {
            setAndInstantiateParcel(fragileParcel);
        }
        
    }

    private void setAndInstantiateParcel(GameObject parcel)
    {
        nextFire = Time.time + fireRate;
        Instantiate(parcel, parcelSpawn.position, parcelSpawn.rotation);
        totalParcels--;
    }
    private bool hasAmmo()
    {
        return totalParcels > 0;
    }
}
