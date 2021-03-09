using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        InGame,
        Pause,
        Death,
    }
    private static GameState _gameState;
    public static GameState gameState
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeGameState(GameState GS)
    {
        _gameState = GS;
        switch(gameState)
        {
            case GameState.InGame:
                break;
            case GameState.Pause:
                break;
            case GameState.Death:
                break;
            default:
                break;
        }
    }
}
