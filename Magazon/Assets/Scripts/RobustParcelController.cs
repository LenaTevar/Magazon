using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Rigidbody
 Angular Drag = 0
 DONT use gravity, because is not that fun. 
     */
public class RobustParcelController : ParcelController
{
    public GameObject deliverAnimation;
    private float robustProbability = 0.9f;
    private int robustBrokenPoints = 1;
    private int robustSuccesPoints = 10;

    void Start()
    { 
        setUpRobustParcel();  
    }
    private void setUpRobustParcel()
    {
        base.setPoints(robustProbability, robustSuccesPoints, robustBrokenPoints);
        base.basicSetUp();

        base.levelController.blockKeyboard();
        delivering();
    }

    private void delivering()
    {
        GameObject deliverAni = Instantiate(deliverAnimation, transform.position, transform.rotation);
        deliverAni.transform.parent = gameObject.transform;        
    }


}
/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 //Rigidbody
 //Angular Drag = 0
 //DONT use gravity, because is not that fun. 
   
    public class RobustParcelController : ParcelController
{
    public GameObject deliverAnimation;
    private float robustProbability = 0.9f;
    private int robustBrokenPoints = 1;
    private int robustSuccesPoints = 10;

    void Start()
    {
        setUpRobustParcel();
    }

    private void delivering()
    {
        GameObject deliverAni = Instantiate(deliverAnimation, transform.position, transform.rotation);
        deliverAni.transform.parent = gameObject.transform;

    }


    private void setUpRobustParcel()
    {
        GameController.IsInputEnabled = false;
        base.setPoints(robustProbability, robustSuccesPoints, robustBrokenPoints);
        base.basicSetUp();
        delivering();
    }
}
*/