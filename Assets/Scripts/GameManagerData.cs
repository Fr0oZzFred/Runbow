using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManagerData
{
    public int candy;
    public int totalLevelDone;
    public int numberOfTails;
    public int[] level;
    public int index;
    public int firstLaunch;

    public GameManagerData(GameManager gameManager)
    {
        int i = 0;
        candy = gameManager.candy;
        totalLevelDone = gameManager.totalLevelDone;
        numberOfTails = gameManager.numberOfTails;
        level = new int[gameManager.level.Length];
        while(i < level.Length)
        {
            if(gameManager.level[i])
            {
                level[i] = 1;
            }
            else
            {
                level[i] = 0;
            }
            i++;
        }
        index = gameManager.index;
        firstLaunch = gameManager.firstLaunch;
    }
}
