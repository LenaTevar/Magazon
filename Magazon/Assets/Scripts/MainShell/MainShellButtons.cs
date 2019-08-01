using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainShellButtons : MonoBehaviour
{
    private bool showCredits = false;
    public GameObject credits;
    public void ExitGame()
    {
        print("Main Shell Buttons: Exit");
        Application.Quit();
    }

    public void LoadGame()
    {
        print("Main Shell Button: Load game");
    }

    public void NewGame()
    {
        print("Main Shell Button: New game");
    }

    public void Credits()
    {
        print("Credits");
        showCredits = !showCredits;
        credits.SetActive(showCredits);
    }
}
