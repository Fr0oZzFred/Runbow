using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{   // Cedric : Choix personnages Frederic : le reste
    public GameObject mainMenu;
    public GameObject menuTuto;
    public GameObject choixPersonages;
    public GameObject hud;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject nextLevel;
    public GameObject gameOverGood;
    public GameObject gameOverBad;
    public GameObject[] stars;
    public GameObject starUI;
    public GameObject candyUI;
    public GameObject buttonAchatPegasus;
    public GameObject buttonAchatBluePegasus;
    public Text textScore;
    public Text textCandy;
    public Text textCandyMenu;
    public Text textLevel;
    public GameObject[] levelButton;
    public GameObject levelSelectionButton;
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
        textLevel.text = "Level : " + LevelManager.instance.level;
    }

    public void DisplayCandy()
    {
        textCandy.text = "Candy : " + GameManager.instance.candy;
        textCandyMenu.text = "Candy : " + GameManager.instance.candy;
    }
    public void SetMainMenuActive()
    {
        mainMenu.SetActive(true);
        menuTuto.SetActive(false);
        hud.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        choixPersonages.SetActive(false);
        UnlockLevelButton();
    }
    public void SetMenuTutoActive()
    {
        mainMenu.SetActive(false);
        menuTuto.SetActive(true);
        hud.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        choixPersonages.SetActive(false);
    }
    public void SetInGameHUDActive()
    {
        mainMenu.SetActive(false);
        menuTuto.SetActive(false);
        hud.SetActive(true);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        choixPersonages.SetActive(false);
    }
    public void SetPauseMenu()
    {
        mainMenu.SetActive(false);
        menuTuto.SetActive(false);
        hud.SetActive(false);
        pauseMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        choixPersonages.SetActive(false);
    }

    public void SetGameOverMenuActive()
    {
        mainMenu.SetActive(false);
        menuTuto.SetActive(false);
        hud.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(true);
        choixPersonages.SetActive(false);
        StartCoroutine(ShowStars());
    }

    public void SetChoixPersonnage()
    {
        mainMenu.SetActive(false);
        menuTuto.SetActive(false);
        hud.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        choixPersonages.SetActive(true);
        if(GameManager.instance.achatPegasus ==1)
        {
            buttonAchatPegasus.SetActive(false);
        }
        if (GameManager.instance.achatBluePegasus == 1)
        {
            buttonAchatBluePegasus.SetActive(false);
        }
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
            SoundManager.instance.PlayGoodGameOverTheme();
            gameOverGood.SetActive(true);
            stars[0].SetActive(true);
            nextLevel.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[1].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[2].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            GameManager.instance.candyPerLevel = 0;
        }
        else if(LevelManager.instance.levelDone && LevelManager.instance.score >= LevelManager.instance.secondStar)
        {
            SoundManager.instance.PlayGoodGameOverTheme();
            gameOverGood.SetActive(true);
            stars[0].SetActive(true);
            nextLevel.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[1].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            GameManager.instance.candyPerLevel = 0;
        }
        else if(LevelManager.instance.levelDone && LevelManager.instance.score >= LevelManager.instance.firstStar)
        {
            SoundManager.instance.PlayGoodGameOverTheme();
            gameOverGood.SetActive(true);
            stars[0].SetActive(true);
            nextLevel.SetActive(true);
            GameManager.instance.candyPerLevel = 0;
        }
        else
        {
            SoundManager.instance.PlayBadGameOverTheme();
            gameOverBad.SetActive(true);
            stars[0].SetActive(false);
            stars[1].SetActive(false);
            stars[2].SetActive(false);
            nextLevel.SetActive(false);
            GameManager.instance.addCandy(GameManager.instance.candyPerLevel * -1);
            GameManager.instance.candyPerLevel = 0;
        }
    }
    
    void UnlockLevelButton()
    {
        for(int i = 0; i < GameManager.instance.totalLevelDone; i++)
        {
            levelButton[i].SetActive(true);
        }
        if (levelButton.Length >= GameManager.instance.totalLevelDone+1)
        {
            levelButton[GameManager.instance.totalLevelDone].SetActive(true);
        }
        if(GameManager.instance.totalLevelDone >= GameManager.instance.totalLevel *0.5)
        {
            levelSelectionButton.SetActive(true);
        }
    }
    
    public void UnlockPegasus(int nombreRequis)
    {
        if (GameManager.instance.achatPegasus < 1)
        {
            GameManager.instance.addCandy(nombreRequis * -1);
            GameManager.instance.candyPerLevel = 0;
            GameManager.instance.achatPegasus = 1;
            buttonAchatPegasus.SetActive(false);
        }
    }
    public void UnlockbluePegasus(int nombreRequis)
    {
        if (GameManager.instance.achatBluePegasus < 1)
        {
            GameManager.instance.addCandy(nombreRequis * -1);
            GameManager.instance.candyPerLevel = 0;
            GameManager.instance.achatBluePegasus = 1;
            buttonAchatBluePegasus.SetActive(false);
        }
    }
}
