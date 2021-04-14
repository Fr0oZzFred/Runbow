using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    private static ScenesManager _instance;
    public static ScenesManager instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    public void LoadNextLevel()
    {
        if (GameManager.instance.totalLevelDone < GameManager.instance.totalLevel)
        {
            SceneManager.LoadScene(GameManager.instance.totalLevelDone + 1);
            GameManager.instance.ChangeGameState(GameManager.GameState.InGame);
        }
        else
        {
            LoadMainMenu();
        }
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
        GameManager.instance.ChangeGameState(GameManager.GameState.InGame);
    }

    public void LoadMainMenu()
    {
        if(LevelManager.instance != null)
        {
            if (!LevelManager.instance.levelDone)
            {
                GameManager.instance.addCandy(GameManager.instance.candyPerLevel * -1);
                GameManager.instance.candyPerLevel = 0;
            }
        }
        SceneManager.LoadScene("MainMenu");
        GameManager.instance.ChangeGameState(GameManager.GameState.MainMenu);
    }

    public void Reload()
    {
        if(!LevelManager.instance.levelDone)
        {
            GameManager.instance.addCandy(GameManager.instance.candyPerLevel * -1);
            GameManager.instance.candyPerLevel = 0;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.instance.ChangeGameState(GameManager.GameState.InGame);
    }

    public void QuitGame()
    {
        GameManager.instance.SaveData();
        Application.Quit();
    }
}
