using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    
    public Text  scoreText;
    public Text parcelsText;
    public Text timer;
    public GameObject endGame;

    private int score;
    private int parcels;

    void Start()
    {
        scoreText.text = "Score: " + score;
        parcelsText.text = "Parcels: " + parcels;
        timer.text = "0 sec";
        endGame.SetActive(false);
    }

    public void UpdateScore(int otherScore)
    {
        score = otherScore;
        scoreText.text = "Score: " + score;
    }

    public void UpdateParcels(int otherParcels)
    {
        parcels = otherParcels;
        string temp = "Parcels: " + parcels;
        parcelsText.text = temp;
    }

    public void showEndGameText(string textToEnd)
    {
        Text temp = endGame.GetComponent<Text>();
        temp.text = textToEnd;
        endGame.SetActive(true);
    }
    public void updateTimer(float timerIn)
    {
        float minutes = (timerIn / 60);
        float seconds = (timerIn % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

   
}

/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    
    public int score;
    public int parcels;
    public Text  scoreText;
    public Text parcelsText;
    public GameObject endGame;

    void Start()
    {
        scoreText.text = "Score: " + score;
        parcelsText.text = "Parcels: " + parcels;
        endGame.SetActive(false);
    }

    public void UpdateScore(int otherScore)
    {
        score += otherScore;
        scoreText.text = "Score: " + score;
    }

    public void UpdateParcels(int otherParcels)
    {
        parcels = otherParcels;
        parcelsText.text = "Parcels: " + parcels;
    }

    public void showEndGameText()
    {
        endGame.SetActive(true);
    }

   
}

     */
