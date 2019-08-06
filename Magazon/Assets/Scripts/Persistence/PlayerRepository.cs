using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class PlayerRepository 
{
    public static void SaveLevel(Level inLevel)
    {
        PlayerPrefs.SetInt(inLevel.ToString(), inLevel.score);
        PlayerPrefs.Save();
    }

    public static Level GetLevel(LevelCode CODE)
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

    public static Level[] GetLevels()
    {
        Level[] levels = new Level[6];
        foreach (LevelCode code in Enum.GetValues(typeof(LevelCode))) 
        {            
            Level l = GetLevel(code);
            levels[(int)code] = l;        
        }

        return levels;
    }

    public static void NewStart()
    {

        foreach (LevelCode code in Enum.GetValues(typeof(LevelCode)))
        {
            Level empty = new Level(code, 0);
            SaveLevel(empty);

        }
    }
}


