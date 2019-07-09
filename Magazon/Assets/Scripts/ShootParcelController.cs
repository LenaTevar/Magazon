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
  
    public float totalParcels = 150;

  
    void Update()
    {
        checkInputEnabledAndFire();
    }

    private void checkInputEnabledAndFire()
    {
        if (GameController.IsInputEnabled)
        {
            fireParcel();
        }
    }
    private void fireParcel()
    {      
        if (Input.GetKeyDown("e"))
        {
            setAndInstantiateParcel(fragileParcel);
        }
        else if (Input.GetKeyDown("q"))
        {
            setAndInstantiateParcel(robustParcel);
        }        
    }

    private void setAndInstantiateParcel(GameObject parcel)
    {
        Instantiate(parcel, parcelSpawn.position, parcelSpawn.rotation);
        
        totalParcels--;
    }
    private bool hasParcels()
    {
        return totalParcels > 0;
    }

  
}
