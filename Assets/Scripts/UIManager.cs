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
    public Text textScore;
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

    void Update()
    {
        textScore.text = "Score : " + GameManager.instance.score;
    }

    public void SetMainMenu(bool boolean)
    {
        mainMenu.SetActive(boolean);
    }

    public void PauseResume()
    {
        if(hud.activeSelf == true)
        {
            hud.SetActive(false);
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            hud.SetActive(true);
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void SetGameOverMenu(bool boolean)
    {
        gameOverMenu.SetActive(boolean);
        if(boolean)
        {
            hud.SetActive(false);
        }
    }
}
