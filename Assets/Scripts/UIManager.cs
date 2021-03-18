using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject hud;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject nextLevel;
    public Text textScore;
    public Text textCandy;
    private static UIManager _instance;
    public static UIManager instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void DisplayScore()
    {
        textScore.text = "Score : " + LevelManager.instance.score;
    }

    public void DisplayCandy()
    {
        textCandy.text = "Score : " + GameManager.instance.candy;
    }
    public void SetMainMenuActive()
    {
        mainMenu.SetActive(true);
        hud.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }
    public void SetInGameHUDActive()
    {
        mainMenu.SetActive(false);
        hud.SetActive(true);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }
    public void SetPauseMenu()
    {
        mainMenu.SetActive(false);
        hud.SetActive(false);
        pauseMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        Time.timeScale = 0;
    }

    public void SetGameOverMenuActive()
    {
        mainMenu.SetActive(false);
        hud.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(true);
        if (LevelManager.instance.score >= LevelManager.instance.nextLevelCondition)
        {
            nextLevel.SetActive(true);
        }
        else
        {
            nextLevel.SetActive(false);
        }
    }
}
