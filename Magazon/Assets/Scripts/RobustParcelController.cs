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
    private Transform objective = null;
    void Start()
    {
        configObjectiveByVanRadar();
        configureParcelSettings();
    }
    private void configObjectiveByVanRadar()
    {
        
        gameObject.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
        objective = transform.parent.GetComponentInChildren<VanRadar>().objective;
        StartCoroutine(delayedDestroy());

    }
    private void configureParcelSettings()
    {
        base.setPoints(robustProbability, robustSuccesPoints, robustBrokenPoints);
        base.levelController = FindObjectOfType<LevelController>();
        base.levelController.blockKeyboard();
        deliveringAnimations();
    }

    private void deliveringAnimations()
    {
        GameObject deliverAni = Instantiate(deliverAnimation, transform.position, transform.rotation);
        deliverAni.transform.parent = gameObject.transform;        
    }
    
    void Update()
    {
        if(objective != null)
        {
            float step = base.speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, objective.position, step);            
        }
       
    }
}