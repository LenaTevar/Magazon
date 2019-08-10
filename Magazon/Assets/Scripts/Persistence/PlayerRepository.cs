using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
/*
 Class: Player Repository
 This class will be used as interface for the persistance type
 finally selected. It has to be as abstract as possible to be used
 with possible increments of levels. 
     */
public sealed class PlayerRepository 
{

    private PlayerRepository() { }

    private static PlayerRepository instance = null;

    public static PlayerRepository Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new PlayerRepository();
                if (instance.isNewGame())
                {
                    instance.NewStart();
                }
            }
            return instance;
        }
    }

    public  void SaveLevel(Level inLevel)
    {
        PlayerPrefs.SetInt(inLevel.levelName.ToString(), inLevel.score);
        PlayerPrefs.Save();
    }
    public  Level GetLevel(LevelCode CODE)
    {
        string name = CODE.ToString();
        int score = 0;
        try
        {
            score = PlayerPrefs.GetInt(name);
        } catch (Exception e)
        {
            Debug.Log("Level not found: " + e);
        }


        return new Level(CODE, score);

    }
    public  Level[] GetLevels()
    {
        Level[] levels = new Level[6];
        foreach (LevelCode code in Enum.GetValues(typeof(LevelCode))) 
        {            
            Level l = GetLevel(code);
            levels[(int)code] = l;        
        }

        return levels;
    }
    public  void NewStart()
    {

        foreach (LevelCode code in Enum.GetValues(typeof(LevelCode)))
        {
            Level empty = new Level(code, 0);
            SaveLevel(empty);

        }
    }

    private bool isNewGame()
    {
        return PlayerPrefs.GetInt("TUTORIAL") == 0;
    }
}


