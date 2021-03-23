using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    public bool green;
    public bool red;
    public bool blue;
    public bool pink;
    public bool purple;
    public bool yellow;
    public bool cyan;
    float time;
    bool done = false;

    void Update()
    {
        Move();
        if (transform.position.x < -20)
        {
            Destroy(this.gameObject);
        }
    }

    void Move()
    {
        Vector3 position = this.transform.position;
        position.x -= LevelManager.instance.speedBackground * Time.deltaTime;
        this.transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBehaviour player = collision.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            VerifColor(player, true);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        PlayerBehaviour player = collision.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            VerifColor(player, false);
        }
    }

    void VerifTiming(bool firstTime)
    {
        LevelManager.instance.addScore(LevelManager.instance.scoreStay);
        if(!done && firstTime)
        {
            LevelManager.instance.addScore(LevelManager.instance.scorePerfect);
            done = true;
            time = 0;
        }
        else if (time < LevelManager.instance.timingGood && !done)
        {
            LevelManager.instance.addScore(LevelManager.instance.scoreGood);
            done = true;
            time = 0;
        }
    }
    
    void VerifColor(PlayerBehaviour player, bool firstTime)
    {
        switch (player.ColorStates)
        {
            case PlayerBehaviour.ColorState.Green:
                VerifColorPlayer(green, player, firstTime);
                break;
            case PlayerBehaviour.ColorState.Red:
                VerifColorPlayer(red, player, firstTime);
                break;
            case PlayerBehaviour.ColorState.Blue:
                VerifColorPlayer(blue, player, firstTime);
                break;
            case PlayerBehaviour.ColorState.Pink:
                VerifColorPlayer(pink, player, firstTime);
                break;
            case PlayerBehaviour.ColorState.Purple:
                VerifColorPlayer(purple, player, firstTime);
                break;
            case PlayerBehaviour.ColorState.Yellow:
                VerifColorPlayer(yellow, player, firstTime);
                break;
            case PlayerBehaviour.ColorState.Cyan:
                VerifColorPlayer(cyan, player, firstTime);
                break;
            default:
                VerifColorPlayer(false, player, firstTime);
                break;
        }
    }

    void VerifColorPlayer(bool color, PlayerBehaviour player, bool firstTime)
    {
        if (color)
        {
            VerifTiming(firstTime);
        }
        else
        {
            time += Time.deltaTime;
            if (time > LevelManager.instance.timingGood)
            {
                time = 0;
                --player.life;
                LevelManager.instance.addScore(LevelManager.instance.scoreMiss);
            }

        }
    }
}
