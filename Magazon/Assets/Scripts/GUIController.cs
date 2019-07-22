using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{

    public Text test;
    public GameObject endGame;
       

    void Start()
    {
        endGame.SetActive(false);
        
    }
    public void updateTest(int score, int objectives, float atime, int parcels)
    {
        float minutes = (atime / 60);
        float seconds = (atime % 60);
        test.text = string.Format("Score: {0} \t\t\tTo Deliver: {1} \t\t\tParcels: {4} \t\t\t{2:00}:{3:00}",
            score,
            objectives,
            minutes,
            seconds,
            parcels);
    } 
    public void showEndGameText(string textToEnd)
    {
        Text temp = endGame.GetComponent<Text>();
        temp.text = textToEnd;
        endGame.SetActive(true);
    }   
}

