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

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.instance.ChangeGameState(GameManager.GameState.InGame);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
        GameManager.instance.ChangeGameState(GameManager.GameState.InGame);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameManager.instance.ChangeGameState(GameManager.GameState.MainMenu);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.instance.ChangeGameState(GameManager.GameState.InGame);
    }

    public void QuitGame()
    {
        //GameManager.instance.SaveData();
        Application.Quit();
    }
}
