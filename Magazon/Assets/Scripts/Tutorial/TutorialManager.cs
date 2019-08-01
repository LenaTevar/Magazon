using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject dialogue;
   
    
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player"))        
            dialogue.SetActive(true); 
    }
    public void OnTriggerExit()
    {
        dialogue.SetActive(false);    
    }
  
}
