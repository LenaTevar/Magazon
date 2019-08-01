using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    public GUIController InGameUI;
    private SoundController sc;
    public int objectives = 5;
    public int parcels = 5;
    public float targetTime = 30.0f;

    private bool IsInputEnabled = true;
    private bool IsDeliveryEnabled = true;
    private bool timeIsOver = false;
    private bool isGameOver = false;
    private bool isWin = false;
    private int score = 0;
    void Start()
    {
        setupUISoundControllers();
    }


    void Update()
    {
        updateUI();
        toggleMap();
        endingOptions();
    }

    private void updateUI()
    {
        if (!isGameOver)
        {
            InGameUI.updateTest(score, objectives, targetTime, parcels);
            targetTime -= Time.deltaTime;
            checkTimingConditions();
        } 
    }

    private void toggleMap()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftShift))
            InGameUI.toggleMap();
    }

    public void updateArrivedParcels(int pointsToAdd)
    {
        if (pointsToAdd > 0)
        {
            objectives--;
            score += pointsToAdd;
        }
       // toggleKeyboard();
        checkEndingConditions();
    }
    public void updateDeliveredParcels()
    {
        parcels--;
        if(parcels < 1)
            IsDeliveryEnabled = false;
    }


    private void setupUISoundControllers()
    {
        sc = FindObjectOfType<SoundController>();

        InGameUI = FindObjectOfType<GUIController>();
    }

    private void checkEndingConditions()
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

    private void checkTimingConditions()
    {
        if (targetTime <= 0.0f)
        {
            timeIsOver = true;
            checkEndingConditions();
        }
    }

    private void gameOver()
    {
        toggleKeyboard();
        isGameOver = true;
        
    }
    private void endingOptions()
    {

        if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (isWin && Input.GetKeyDown("n"))
        {
            print("next level");

        }
    }
    public void toggleKeyboard()
    {
        IsInputEnabled = !IsInputEnabled;
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

        InGameUI.showWin(score);
        isWin = true;
    }
    public void showLoseUI()
    {
        InGameUI.showLose();
        isWin = false;
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void playSoundEffect(string name)
    {
        sc.play(name);
    }
}
