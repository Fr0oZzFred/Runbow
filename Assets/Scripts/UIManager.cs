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
    public GameObject choixPersonages;
    public GameObject gameOverGood;
    public GameObject gameOverBad;
    public GameObject[] stars;
    public GameObject starUI;
    public GameObject candyUI;
    public Text textScore;
    public Text textCandy;
    public GameObject[] levelButton;
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
        choixPersonages.SetActive(false);
        UnlockLevelButton();
    }
    public void SetInGameHUDActive()
    {
        mainMenu.SetActive(false);
        hud.SetActive(true);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        choixPersonages.SetActive(false);
    }
    public void SetPauseMenu()
    {
        mainMenu.SetActive(false);
        hud.SetActive(false);
        pauseMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        choixPersonages.SetActive(false);
    }

    public void SetGameOverMenuActive()
    {
        mainMenu.SetActive(false);
        hud.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(true);
        choixPersonages.SetActive(false);
        StartCoroutine(ShowStars());
    }

    public void SetChoixPersonnage()
    {
        mainMenu.SetActive(false);
        hud.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        choixPersonages.SetActive(true);
    }

    IEnumerator ShowStars()
    {
        gameOverGood.SetActive(false);
        gameOverBad.SetActive(false);
        stars[0].SetActive(false);
        stars[1].SetActive(false);
        stars[2].SetActive(false);
        nextLevel.SetActive(false);
        if (LevelManager.instance.levelDone && LevelManager.instance.score >= LevelManager.instance.thirdStar)
        {
            gameOverGood.SetActive(true);
            stars[0].SetActive(true);
            nextLevel.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[1].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[2].SetActive(true);
            yield return new WaitForSeconds(1.0f);
        }
        else if(LevelManager.instance.levelDone && LevelManager.instance.score >= LevelManager.instance.secondStar)
        {
            gameOverGood.SetActive(true);
            stars[0].SetActive(true);
            nextLevel.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[1].SetActive(true);
            yield return new WaitForSeconds(1.0f);
        }
        else if(LevelManager.instance.levelDone && LevelManager.instance.score >= LevelManager.instance.firstStar)
        {
            gameOverGood.SetActive(true);
            stars[0].SetActive(true);
            nextLevel.SetActive(true);
        }
        else
        {
            gameOverBad.SetActive(true);
            stars[0].SetActive(false);
            stars[1].SetActive(false);
            stars[2].SetActive(false);
            nextLevel.SetActive(false);
        }
    }
    
    void UnlockLevelButton()
    {
        for(int i =0; i < GameManager.instance.totalLevelDone+1; i++)
        {
            levelButton[i].SetActive(true);
        }
    }
}
