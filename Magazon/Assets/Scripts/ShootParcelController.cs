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
    public GameObject levelControllerHolder;

    private LevelController levelController;
    void Start()
    {
        levelController = FindObjectOfType<LevelController>();

    }

    void Update() { checkInputEnabledAndFire(); }

    private void checkInputEnabledAndFire()
    {
        if (levelController.isDeliveryEnabled())
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
        levelController.updateDeliveredParcels();
       
    }
    


}
/*
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootParcelController : MonoBehaviour
{
    [Header("Shooting Parcel")]
    public GameObject fragileParcel;
    public GameObject robustParcel;
    [Tooltip("Location of the spawn for parcels.")]
    public Transform parcelSpawn;
    [Header("POTATO")]
    public int totalParcels = 10;
    private GUIController GUIController;

  
    void Start() { setUpGUIController(); }

    void Update() { checkInputEnabledAndFire(); }

    private void checkInputEnabledAndFire()
    {
        if (GameController.IsInputEnabled && hasParcels())
        {
            fireParcel();
        }
        else if (!hasParcels())
        {
            endGame();
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

    private void endGame()
    {
        StartCoroutine(delayEndGame());
        
    }

    private void setAndInstantiateParcel(GameObject parcel)
    {
        Instantiate(parcel, parcelSpawn.position, parcelSpawn.rotation);        
        totalParcels--;
        notifyGUIController();
    }
    private bool hasParcels()
    {
        return totalParcels > 0;
    }

    private void setUpGUIController()
    {
        GameObject tmp = GameObject.FindGameObjectWithTag("GUIController");
        GUIController = tmp.GetComponent<GUIController>();
        GUIController.UpdateParcels(totalParcels);
    }

    private void notifyGUIController()
    {
        GUIController.UpdateParcels(totalParcels);
    }

    static IEnumerator delayEndGame()
    {
        yield return new WaitForSeconds(5);
        GameController.GameOver();

    }

}
*/
