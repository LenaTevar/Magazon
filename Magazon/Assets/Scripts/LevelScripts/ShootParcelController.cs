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

    private LevelController levelController;
    void Start()
    {
        levelController = FindObjectOfType<LevelController>();

    }

    void Update() { checkInputEnabledAndFire(); }

    /*
     Method: checkInputEnabledAndFire
     Check if Level Controller has blocked the input for the keyboard.
     That means a parcel is being delivered at the moment and next shoot 
     has to wait. 
         */
    private void checkInputEnabledAndFire()
    {
        if (levelController.isDeliveryEnabled())
        {
            fireParcel();
        }
    }

   

    private void fireParcel()
    {      
        if (Input.GetKeyDown(KeyCode.L))
        {
            setAndInstantiateParcel(fragileParcel);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(deliverRobustParcel());
        }
    }

   

    private void setAndInstantiateParcel(GameObject parcel)
    {

        Instantiate(parcel, parcelSpawn.position, parcelSpawn.rotation);        
        levelController.updateDeliveredParcels();
       
    }
    

    public IEnumerator deliverRobustParcel()
    {
        levelController.playSoundEffect("handBrake");
        levelController.toggleKeyboard();
        levelController.updateDeliveredParcels();
        yield return new WaitForSeconds(2);
        Instantiate(robustParcel, parcelSpawn.position, parcelSpawn.rotation);
    }
}
