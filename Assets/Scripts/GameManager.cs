using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int candy = 0;
    public int candyPerLevel = 0;
    public int totalLevel = 5;
    public int totalLevelDone = 0;
    public int numberOfTails = 0;
    public bool[] level;
    public int[] tailsCondition;
    public int index = 0;
    public int premierTuto = 0;
    public bool choixLicorne = false;
    public bool choixPegase = false;
    public bool choixPegaseNoir = false;
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

    public void SaveData()
    {
        SaveSystem.SaveGameManager(this);
    } 
    public void LoadData()
    {
        GameManagerData data = SaveSystem.LoadGameManager();
        int i = 0;
        candy = data.candy;
        totalLevelDone = data.totalLevelDone;
        numberOfTails = data.numberOfTails;
        level = new bool[data.level.Length];
        while(i < level.Length)
        {
            if(data.level[i] == 0)
            {
                level[i] = false;
            }
            else
            {
                level[i] = true;
            }
            i++;
        }
        index = data.index;
        premierTuto = data.premierTuto;
        addCandy(0);
    }
    public void addCandy(int amount)
    {
        candy += amount;
        UIManager.instance.DisplayCandy();
        candyPerLevel += amount;
    }

    public void ChangeGameState(GameState GS)
    {
        bool pauseFix = false;
        if(_gameState == GameState.Pause)
        {
            pauseFix = true;
        }
        _gameState = GS;
        switch (_gameState)
        {
            case GameState.MainMenu:
                Time.timeScale = 1;
                UIManager.instance.SetMainMenuActive();
                if(!SoundManager.instance.mainMenuTheme.isPlaying)
                {
                    SoundManager.instance.PlayMainMenuTheme();
                }
                break;
            case GameState.ChoixPers:
                Time.timeScale = 0;
                if(premierTuto == 0)
                {
                    premierTuto = 1;
                    UIManager.instance.SetMenuTutoActive();
                }
                else
                {
                    UIManager.instance.SetChoixPersonnage();
                }
                break;
            case GameState.InGame:
                Time.timeScale = 1;
                UIManager.instance.SetInGameHUDActive();
                if(pauseFix)
                {
                    LevelManager.instance.inGameTheme.UnPause();
                }
                break;
            case GameState.Pause:
                Time.timeScale = 0;
                UIManager.instance.SetPauseMenu();
                LevelManager.instance.inGameTheme.Pause();
                break;
            case GameState.Death:
                LevelManager.instance.speedBackground = 0;
                LevelManager.instance.speedPlatform = 0;
                UIManager.instance.SetGameOverMenuActive();
                LevelManager.instance.inGameTheme.Stop();
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
    }
    public void ChoixPegase()
    {
        choixLicorne = false;
        choixPegase = true;
        choixPegaseNoir = false;
    }
    public void ChoixPegaseNoir()
    {
        choixLicorne = false;
        choixPegase = false;
        choixPegaseNoir = true;
    }
}

