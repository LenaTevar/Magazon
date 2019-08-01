using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{

    public Text test;
    public GameObject endGame;
    public GameObject map;
    private bool mapFlag = false; 

    void Start()
    {
        endGame.SetActive(false);
        map.SetActive(false);
        
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
    
    public void showWin(int score)
    {
        string win = string.Format("YOU WIN - SCORE: {0} \r\n Space to Replay \t N to Next Level", score);
        showEndGameText(win);
    }

    public void showLose()
    {
        string lose = "YOU LOSE \r\n Space to Replay";
        showEndGameText(lose);
    }

    public void toggleMap()
    {
        mapFlag = !mapFlag;
        map.SetActive(mapFlag);
    }

}

