using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int candy = 0;
    int totalLevelDone = 0;
    public int numberOfTails = 0;
    public bool[] level;
    public bool choixLicorne = false;
    public bool choixPegase = false;
    public bool choixPegaseNoir = false;
    public int[] tailsCondition;
    int index = 0;
    public enum GameState
    {
        MainMenu,
        InGame,
        ChoixPers,
        Pause,
        Death,
    }
    private static GameState _gameState;
    public static GameState GameStates
    {
        get
        {
            return _gameState;
        }
    }

    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
        addCandy(0);
    }

    public void addCandy(int amount)
    {
        candy += amount;
        UIManager.instance.DisplayCandy();
    }

    public void ChangeGameState(GameState GS)
    {
        _gameState = GS;
        switch (_gameState)
        {
            case GameState.MainMenu:
                Time.timeScale = 1;
                UIManager.instance.SetMainMenuActive();
                break;
            case GameState.InGame:
                Time.timeScale = 1;
                UIManager.instance.SetInGameHUDActive();
                break;
            case GameState.ChoixPers:
                Time.timeScale = 0;
                UIManager.instance.SetChoixPersonnage();
                break;
            case GameState.Pause:
                Time.timeScale = 0;
                UIManager.instance.SetPauseMenu();
                break;
            case GameState.Death:
                LevelManager.instance.speedBackground = 0;
                LevelManager.instance.speedPlatform = 0;
                UIManager.instance.SetGameOverMenuActive();
                UpgradeTail();
                break;
        }
    }

    void UpgradeTail()
    {
        if (LevelManager.instance.levelDone && !level[LevelManager.instance.level])
        {
            level[LevelManager.instance.level] = true;
            totalLevelDone++;
            if (totalLevelDone >= tailsCondition[index])
            {
                if (numberOfTails < 10)
                {
                    numberOfTails++;
                }
                if (index < tailsCondition.Length)
                {
                    index++;
                }
            }
        }
    }
    public void ChangeGameStateInGame()
    {
        ChangeGameState(GameState.InGame);
    }

    public void ChangeGameStatePause()
    {
        ChangeGameState(GameState.Pause);
    }

    public void ChangeGameStateChoixPers()
    {
        ChangeGameState(GameState.ChoixPers);
    }

    public void ChoixLicorne()
    {
         choixLicorne = true;
         choixPegase = false;
         choixPegaseNoir = false;
         ChangeGameStateInGame();
    }
    public void ChoixPegase()
    {
        choixLicorne = false;
        choixPegase = true;
        choixPegaseNoir = false;
        ChangeGameStateInGame();
    }
    public void ChoixPegaseNoir()
    {
        choixLicorne = false;
        choixPegase = false;
        choixPegaseNoir = true;
        ChangeGameStateInGame();
    }
}

