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
    [Header ("Load Level Buttons")]
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
        if (!showShell)
        {
            PlayerRepository.Instance.NewStart();
            SceneManager.LoadScene("Tutorial");
        }
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
        Level[] currentLevels = PlayerRepository.Instance.GetLevels();        
        
        for (int i = 0; i < loadbtns.Length; i++)
        {
            if( currentLevels[i].score == 0)
            {
                loadbtns[i].enabled = false;            
            }
            else
            {
                loadbtns[i].GetComponentInChildren<Text>().text = "TUTORIAL - SCORE: " + currentLevels[i].score;
            }
        }
    }

    public void sendToTutorial()
    {
        LoadScene(1);
    }
    public void sendToL1()
    {
        LoadScene(2);
    }
    public void sendToL2()
    {
        LoadScene(3);
    }
    public void sendToL3()
    {
        LoadScene(4);
    }
    public void sendToL4()
    {
        LoadScene(5);
    }
    public void sendToL5()
    {
        LoadScene(6);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
