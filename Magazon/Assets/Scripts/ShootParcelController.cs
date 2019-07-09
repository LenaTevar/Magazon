using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootParcelController : MonoBehaviour
{
    [Header("Shooting Parcel")]
    public GameObject parcel;
    public Transform parcelSpawn;
    public float fireRate;
    private float nextFire = 0;
    public float totalParcels = 5;

    void Update()
    {
        if(Time.time > nextFire || nextFire == 0)
        {
            nextFire = Time.time + fireRate;
            checkAmmoAndFire();
        }
    }

    private void checkAmmoAndFire()
    {
        if (hasAmmo())
            fireParcel();
        else
            return;
    }

    private void fireParcel()
    {      
        if (Input.GetKey("e"))
        {
            nextFire = Time.time + fireRate;
            Instantiate(parcel, parcelSpawn.position, parcelSpawn.rotation);
            consumeAmmo();
        }
        else if (Input.GetKey("q"))
        {
            nextFire = Time.time + fireRate;
            Instantiate(parcel, parcelSpawn.position, parcelSpawn.rotation);
            consumeAmmo();
        }
        
    }

    private void consumeAmmo() { totalParcels--; }
    private bool hasAmmo()
    {
        return totalParcels > 0;
    }
}
