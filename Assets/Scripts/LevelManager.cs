using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int score = -1;
    public int firstStar = 50;
    public int secondStar = 50;
    public int thirdStar = 50;
    public float speedPlatform = 3;
    public float speedBackground = 3;
    public float timingPerfect = 0.5f;
    public float timingGood = 2;
    public int scorePerfect = 1000;
    public int scoreGood = 500;
    public int scoreMiss = 0;
    public int scoreStay = 1;
    public bool levelDone = false;

    private static LevelManager _instance;
    public static LevelManager instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
        addScore(1);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 position = transform.position;
        position.x -= speedPlatform * Time.deltaTime;
        transform.position = position;
    }

    public void addScore(int amount)
    {
        score += amount;
        UIManager.instance.DisplayScore();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBehaviour player = collision.GetComponent<PlayerBehaviour>();
        {
            if(player != null)
            {
                levelDone = true;
                GameManager.instance.ChangeGameState(GameManager.GameState.Death);
            }
        }
    }
}
