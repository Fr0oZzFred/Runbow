using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int score = -1;
    public int nextLevelCondition = 50;
    public float speedPlatform = 3;
    public float speedBackground = 1;
    public float timingPerfect = 0.5f;
    public float timingGood = 2;
    public int scorePerfect = 1000;
    public int scoreGood = 500;
    public int scoreMiss = 0;
    public int scoreStay = 1;

    private static LevelManager _instance;
    public static LevelManager instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
        addScore(1);
    }
    public void addScore(int amount)
    {
        score += amount;
        UIManager.instance.DisplayScore();
    }
}
