using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text UIText;
    public GameObject endGame;
    public GameObject map;
    private bool mapFlag = false; 

    void Start()
    {
        endGame.SetActive(false);
        map.SetActive(false);
        
    }
    public void updatePlayerInfo(int score, int objectives, float atime, int parcels)
    {
        float minutes = (atime / 60);
        float seconds = (atime % 60);
        UIText.text = string.Format("Score: {0} \t\t\tTo Deliver: {1} \t\t\tParcels: {4} \t\t\t{2:00}:{3:00}",
            score,
            objectives,
            minutes,
            seconds,
            parcels);
    } 
    public void showEndGameText(string textToEnd)
    {
        endGame.GetComponentInChildren<Text>().text = textToEnd;
        endGame.SetActive(true);
    }
    
    public void showWin(int score)
    {
        string win = string.Format("YOU WIN \r\n Score + Extra Time: {0} \r\n\r\n U to Replay \r\nO to Next Level \r\nESC to Menu", score);
        showEndGameText(win);
    }

    public void showLose()
    {
        string lose = "YOU LOSE \r\n U to Replay \r\nESC to Menu";
        showEndGameText(lose);
    }

    public void toggleMap()
    {
        mapFlag = !mapFlag;
        map.SetActive(mapFlag);
    }

}

