using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level 
{
   
    public LevelCode levelName;
    public int score;

    public Level(LevelCode inname, int inScore)
    {
        levelName = inname;
        score = inScore;
    }
  
}
public enum LevelCode
{
    TUTORIAL = 0, ONE = 1, TWO = 2, THREE = 3, FOUR = 4, FIVE = 5
}