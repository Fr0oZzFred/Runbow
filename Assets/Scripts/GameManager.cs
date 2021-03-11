using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    public enum GameState
    {
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

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void ChangeGameState(GameState GS)
    {
        _gameState = GS;
        switch(_gameState)
        {
            case GameState.InGame:
                break;
            case GameState.Pause:
                break;
            case GameState.Death:
                break;
        }
    }
}
