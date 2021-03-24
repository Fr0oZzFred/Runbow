using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    public int firstColor;
    float time;
    bool done = false;
    SpriteRenderer spriteRenderer;
    public Sprite[] backgroundColor;
    public enum BackGroundColorState
    {
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
        switch(firstColor)
        {
            case 0:
                ChangeBKColorState(BackGroundColorState.Green);
                break;
            case 1:
                ChangeBKColorState(BackGroundColorState.Red);
                break;
            case 2:
                ChangeBKColorState(BackGroundColorState.Blue);
                break;
            case 3:
                ChangeBKColorState(BackGroundColorState.Pink);
                break;
            case 4:
                ChangeBKColorState(BackGroundColorState.Purple);
                break;
            case 5:
                ChangeBKColorState(BackGroundColorState.Yellow);
                break;
            case 6:
                ChangeBKColorState(BackGroundColorState.Cyan);
                break;

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

    void ChangeBackGroundColor(int colorInt)
    {
        spriteRenderer.sprite = backgroundColor[colorInt];
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
        }
    }

    void VerifColorPlayer(BackGroundColorState color, PlayerBehaviour player, bool firstTime)
    {
        if (ColorStates == color)
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

    void VerifTiming(bool firstTime)
    {
        LevelManager.instance.addScore(LevelManager.instance.scoreStay);
        if (!done && firstTime)
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

    void ChangeBKColorState(BackGroundColorState colorState)
    {
        _colorState = colorState;
        switch (_colorState)
        {
            case BackGroundColorState.Green:
                ChangeBackGroundColor(0);
                break;
            case BackGroundColorState.Red:
                ChangeBackGroundColor(1);
                break;
            case BackGroundColorState.Blue:
                ChangeBackGroundColor(2);
                break;
            case BackGroundColorState.Pink:
                ChangeBackGroundColor(3);
                break;
            case BackGroundColorState.Purple:
                ChangeBackGroundColor(4);
                break;
            case BackGroundColorState.Yellow:
                ChangeBackGroundColor(5);
                break;
            case BackGroundColorState.Cyan:
                ChangeBackGroundColor(6);
                break;
        }
    }
}
