using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManagerData
{
    public int candy = 0;
    public int totalLevelDone = 0;
    public int numberOfTails = 0;
    public bool[] level;
    public int index = 0;

    public GameManagerData(GameManager gameManager)
    {
        candy = gameManager.candy;
        totalLevelDone = gameManager.totalLevelDone;
        numberOfTails = gameManager.numberOfTails;
        for (int i = 0; 0 < level.Length; i++)
        {
            level[i] = gameManager.level[i];
        }
        index = gameManager.index;
    }
}
