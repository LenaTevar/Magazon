using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static GUIController InGameUI;
    public int objectives = 5;
    public int parcels = 5;
    public float targetTime = 30.0f;

    private bool IsInputEnabled = true;
    private bool IsDeliveryEnabled = true;
    private bool timeIsOver = false;
    private bool isGameOver = false;
    private int score = 0;
    private SoundController sc;
    void Start()
    {
        setUpGUIController();
        sc = FindObjectOfType<SoundController>();
    }


    void Update()
    {
        if (!timeIsOver && !isGameOver)
        {
            InGameUI.updateTest(score, objectives, targetTime, parcels);
            
            targetTime -= Time.deltaTime;
            checkTimingConditions();
        }
        
    }

    public void updateArrivedParcels(int pointsToAdd)
    {
        score += pointsToAdd;

        if (pointsToAdd > 0)
        {
            objectives--;
        } else if (pointsToAdd < 0)
        {
            //TOCHANGE
            pointsToAdd = 0;
        }


        openKeyboard();

        checkEndingConditions();
    }
    public void updateDeliveredParcels()
    {
        parcels--;
        if(parcels < 1)
        {
            IsDeliveryEnabled = false;
        }
    }
   

    private  void setUpGUIController()
    {
        GameObject tmp = GameObject.FindGameObjectWithTag("GUIController");
        InGameUI = tmp.GetComponent<GUIController>();


    }

    public void checkEndingConditions()
    {
        if (objectives < 1)
        {
            showWinUI();
            gameOver();
        }
        else if (parcels < 1 || timeIsOver)
        {
            showLoseUI();
            gameOver();
        }

    }

    public void checkTimingConditions()
    {
        if (targetTime <= 0.0f)
        {
            timeIsOver = true;
            checkEndingConditions();
        }
    }

    public void gameOver()
    {
        blockKeyboard();
        isGameOver = true;
    }

    public void blockKeyboard()
    {
        IsInputEnabled = false;
    }

    public void openKeyboard()
    {
        if(!IsInputEnabled)
            IsInputEnabled = true;
    }

    public bool isKeyboardEnabled()
    {
        return IsInputEnabled;
    }
    public bool isDeliveryEnabled()
    {
        return IsDeliveryEnabled;
    }
    public void showWinUI()
    {
        InGameUI.showEndGameText("YOU WIN - SCORE: " + score);
    }
    public void showLoseUI()
    {
        InGameUI.showEndGameText("YOU LOSE");
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void playSoundEffect(string name)
    {
        Debug.Log("Level Controller play sound effect " + name);
        sc.play(name);
    }

}
