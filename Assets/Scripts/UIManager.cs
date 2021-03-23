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
    public GameObject[] stars;
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
        textCandy.text = "Candy : " + GameManager.instance.candy;
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
        StartCoroutine(ShowStars());
    }

    IEnumerator ShowStars()
    {
        stars[0].SetActive(false);
        stars[1].SetActive(false);
        stars[2].SetActive(false);
        nextLevel.SetActive(false);
        if (LevelManager.instance.levelDone && LevelManager.instance.score >= LevelManager.instance.thirdStar)
        {
            stars[0].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[1].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[2].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            nextLevel.SetActive(true);
        }
        else if(LevelManager.instance.levelDone && LevelManager.instance.score >= LevelManager.instance.secondStar)
        {
            stars[0].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[1].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            nextLevel.SetActive(true);
        }
        else if(LevelManager.instance.levelDone && LevelManager.instance.score >= LevelManager.instance.firstStar)
        {
            stars[0].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            nextLevel.SetActive(true);
        }
        else
        {
            stars[0].SetActive(false);
            stars[1].SetActive(false);
            stars[2].SetActive(false);
            nextLevel.SetActive(false);
        }
    }
    
}
