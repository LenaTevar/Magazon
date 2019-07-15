using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static GUIController InGameUI;

    private bool IsInputEnabled = true;
    private bool IsDeliveryEnabled = true;
    private bool timeIsOver = false;
    private bool isGameOver = false;
    private int score = 0;

    public int objectives = 5;
    public int parcels = 5;
    public float targetTime = 30.0f;
    void Start()
    {
        setUpGUIController();
    }


    void Update()
    {
        if (!timeIsOver && !isGameOver)
        {

            InGameUI.updateTimer(targetTime);
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
        }

        InGameUI.UpdateScore(score);

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
        InGameUI.UpdateParcels(parcels);
    }
   

    private  void setUpGUIController()
    {
        GameObject tmp = GameObject.FindGameObjectWithTag("GUIController");
        InGameUI = tmp.GetComponent<GUIController>();

        InGameUI.UpdateScore(score);

        InGameUI.UpdateParcels(parcels);

        InGameUI.updateTimer(targetTime);
    }

    public void checkEndingConditions()
    {
        if (objectives < 1)
        {
            youWin();
        }
        else if (parcels < 1 || timeIsOver)
        {
            youLose();
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

    public void youWin()
    {
        blockKeyboard();
        showWinUI();
        isGameOver = true;
    }
    public void youLose()
    {
        blockKeyboard();
        showLoseUI();
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

    static IEnumerator delayEndGame()
    {
        yield return new WaitForSeconds(5);
        

    }
}
