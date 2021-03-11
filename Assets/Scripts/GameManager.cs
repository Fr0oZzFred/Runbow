using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    public enum GameState
    {
        MainMenu,
        InGame,
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
    }

    public void ChangeGameState(GameState GS)
    {
        _gameState = GS;
        switch(_gameState)
        {
            case GameState.MainMenu:
                UIManager.instance.SetGameOverMenu(false);
                UIManager.instance.SetMainMenu(true);
                break;
            case GameState.InGame:
                UIManager.instance.SetGameOverMenu(false);
                UIManager.instance.SetMainMenu(false);
                UIManager.instance.PauseResume();
                break;
            case GameState.Pause:
                break;
            case GameState.Death:
                UIManager.instance.SetGameOverMenu(true);
                break;
        }
    }
}
