using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    public bool random;
    public bool thunder;
    public GameObject thunderBox;
    public int color;
    float time;
    bool done = false;
    SpriteRenderer spriteRenderer;
    public Sprite[] backgroundColor;
    public enum BackGroundColorState
    {
        White,
        Green,
        Red,
        Blue,
        Pink,
        Purple,
        Yellow,
        Cyan,
    }
    private BackGroundColorState _colorState;
    public BackGroundColorState ColorStates
    {
        get
        {
            return _colorState;
        }
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(random)
        {
            ChangeBKColorState((BackGroundColorState)RandomBK());
        }
        else if(thunder)
        {
            thunderBox.SetActive(true);
        }
        else
        {
            ChangeBKColorState((BackGroundColorState)color);
        }
    }
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

    void ChangeBackGroundColor(int colorInt)
    {
        spriteRenderer.sprite = backgroundColor[colorInt];
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

    public int RandomBK()
    {
        int tutu = Random.Range(1, 9);
        return tutu;
    }

    public void ChangeBKColorState(BackGroundColorState colorState)
    {
        _colorState = colorState;
        switch (_colorState)
        {
            case BackGroundColorState.White:
                ChangeBackGroundColor(0);
                break;
            case BackGroundColorState.Green:
                ChangeBackGroundColor(1);
                break;
            case BackGroundColorState.Red:
                ChangeBackGroundColor(2);
                break;
            case BackGroundColorState.Blue:
                ChangeBackGroundColor(3);
                break;
            case BackGroundColorState.Pink:
                ChangeBackGroundColor(4);
                break;
            case BackGroundColorState.Purple:
                ChangeBackGroundColor(5);
                break;
            case BackGroundColorState.Yellow:
                ChangeBackGroundColor(6);
                break;
            case BackGroundColorState.Cyan:
                ChangeBackGroundColor(7);
                break;
        }
    }

    void VerifColor(PlayerBehaviour player, bool firstTime)
    {
        switch (player.ColorStates)
        {
            case PlayerBehaviour.ColorState.Green:
                VerifColorPlayer(BackGroundColorState.Green, player, firstTime);
                break;
            case PlayerBehaviour.ColorState.Red:
                VerifColorPlayer(BackGroundColorState.Red, player, firstTime);
                break;
            case PlayerBehaviour.ColorState.Blue:
                VerifColorPlayer(BackGroundColorState.Blue, player, firstTime);
                break;
            case PlayerBehaviour.ColorState.Pink:
                VerifColorPlayer(BackGroundColorState.Pink, player, firstTime);
                break;
            case PlayerBehaviour.ColorState.Purple:
                VerifColorPlayer(BackGroundColorState.Purple, player, firstTime);
                break;
            case PlayerBehaviour.ColorState.Yellow:
                VerifColorPlayer(BackGroundColorState.Yellow, player, firstTime);
                break;
            case PlayerBehaviour.ColorState.Cyan:
                VerifColorPlayer(BackGroundColorState.Cyan, player, firstTime);
                break;
            default:
                VerifColorPlayer(BackGroundColorState.White, player, firstTime);
                break;
        }
    }

    void VerifColorPlayer(BackGroundColorState color, PlayerBehaviour player, bool firstTime)
    {
        if (ColorStates == color)
        {
            VerifTiming(firstTime, player);
        }
        else
        {
            time += Time.deltaTime;
            if (time > LevelManager.instance.timingGood)
            {
                time = 0;
                --player.life;
                player.AnimationScore("miss");
                LevelManager.instance.addScore(LevelManager.instance.scoreMiss);
            }

        }
    }

    void VerifTiming(bool firstTime, PlayerBehaviour player)
    {
        LevelManager.instance.addScore(LevelManager.instance.scoreStay);
        if (!done && firstTime)
        {
            player.AnimationScore("perfect");
            LevelManager.instance.addScore(LevelManager.instance.scorePerfect);
            done = true;
            time = 0;
        }
        else if (time < LevelManager.instance.timingGood && !done)
        {
            player.AnimationScore("good");
            LevelManager.instance.addScore(LevelManager.instance.scoreGood);
            done = true;
            time = 0;
        }
    }

}
