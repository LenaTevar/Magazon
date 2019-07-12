using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
}

/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool IsInputEnabled = true;
    public static bool IsGameOver = false;

    public static GUIController InGameUI;

    public static void GameOver()
    {
        setUpGUIController();
        IsInputEnabled = false;
        IsGameOver = true;
        

    }
    private static void setUpGUIController()
    {
        GameObject tmp = GameObject.FindGameObjectWithTag("GUIController");
        InGameUI = tmp.GetComponent<GUIController>();
        InGameUI.showEndGameText();
     
    }
}

     */
