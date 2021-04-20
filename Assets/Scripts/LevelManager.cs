using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int score = 0;
    public int firstStar = 50;
    public int secondStar = 50;
    public int thirdStar = 50;
    public float speedPlatform = 3;
    public float speedBackground = 3;
    public float timingGood = 2;
    public int scorePerfect = 1000;
    public int scoreGood = 500;
    public int scoreMiss = 0;
    public int scoreStay = 1;
    public int level;
    public int numberOfColor;
    public bool levelDone = false;
    public AudioSource inGameTheme;

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
        addScore(0);
        SoundManager.instance.mainMenuTheme.Stop();
        SoundManager.instance.badGameOverSound.Stop();
        SoundManager.instance.goodGameOverSound.Stop();
        inGameTheme.Play();
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
                player.ChangeIdle();
                if(score >=firstStar)
                {
                    levelDone = true;
                }
                GameManager.instance.ChangeGameState(GameManager.GameState.Death);
            }
        }
    }
}
