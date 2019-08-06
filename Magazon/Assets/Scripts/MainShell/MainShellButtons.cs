using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainShellButtons : MonoBehaviour
{
    private bool showShell = false;
    public GameObject credits;
    public GameObject loadLevels;

    public Button[] loadbtns;

   
     
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadGame()
    {
        toggleShell();
        setupLevelBtns();
        loadLevels.SetActive(showShell);

    }

    public void NewGame()
    {
        PlayerRepository.NewStart();
        SceneManager.LoadScene("Tutorial");
    }

    public void Credits()
    {
        toggleShell();
        credits.SetActive(showShell);
    }

    private void toggleShell()
    {
        showShell = !showShell;
    }

    public void setupLevelBtns()
    {
        Level[] currentLevels = PlayerRepository.GetLevels();
        
        foreach(Level l in currentLevels)
        {
            if(l.score <= 0)
            {

                //tutorial.enabled = false;
                //tutorial.GetComponentInChildren<Text>().text = "Tutorial - Not Completed";
            }
        }


        for (int i = 0; i < loadbtns.Length; i++)
        {
            if( currentLevels[i].score == 0)
            {
                loadbtns[i].enabled = false;
                loadbtns[i].GetComponentInChildren<Text>().text += " - NOT COMPLETED";             
            }
            else
            {
                loadbtns[i].GetComponentInChildren<Text>().text += " - SCORE: " + currentLevels[i].score;
            }
        }


    }

}
