using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float jumpPower = 7.0f;
    public int life = 2;
    public GameObject starEffect;
    public GameObject candyEffect;
    public GameObject tailsGO;
    TailsBehaviour tails;
    SpriteRenderer spriteRenderer;
    public Sprite[] playerSkins;
    float input1 = 0;
    float input2 = 0;
    float input3 = 0;
    float input4 = 0;
    Rigidbody2D rigidbody2d;
    public enum MoveState
    {
        Jump,
        Run,
        Death,
    }
    private MoveState _moveStates;
    public MoveState MoveStates
    {
        get
        {
            return _moveStates;
        }
    }

    public enum ColorState
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
    private ColorState _colorState;
    public ColorState ColorStates
    {
        get
        {
            return _colorState;
        }
    }
    void Start()
    {
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        this.enabled = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        tails = tailsGO.GetComponent<TailsBehaviour>();
        UpgradeTail(GameManager.instance.numberOfTails);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.MoveStates == MoveState.Run)
        {
            this.Jump(jumpPower);
        }
        ChangeColor(input1, input2, input3, input4);
        Pause();
        VerifDeath();
    }

    public void Jump(float jump)
    {
        rigidbody2d.velocity = new Vector2(0.0f, jump);
        ChangeMoveState(MoveState.Jump);
    }
    
    public void UpgradeTail(int number)
    {
        if(number < tails.sprite.Length)
        {
            tails.ChangeTail(number);
        }
    }

    public void CandyEffect()
    {
        GameObject candyObject = Instantiate(candyEffect, this.transform.position, Quaternion.identity);
    }

    public void AnimationScore(string score)
    {
        if(score == "perfect")
        {
            GameObject starObject = Instantiate(starEffect, this.transform.position, Quaternion.identity);
        }
        else if (score == "good")
        {

        }
        else
        {

        }
    }

    void VerifDeath()
    {
        if (transform.position.y < -4 || transform.position.y > 8 || transform.position.x < -5 || life < 0)
        {
            GameManager.instance.ChangeGameState(GameManager.GameState.Death);
            this.enabled = false;
        }
    }
    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.GameStates == GameManager.GameState.Pause)
            {
                GameManager.instance.ChangeGameState(GameManager.GameState.InGame);
            }
            else
            {
                GameManager.instance.ChangeGameState(GameManager.GameState.Pause);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Platform platform = collision.collider.GetComponent<Platform>();
        if( platform != null)
        {
            ChangeMoveState(MoveState.Run);
        }
    }

    void ChangeSprite(int colorInt)
    {
        spriteRenderer.sprite = playerSkins[colorInt];
    }

    public void ChangeMoveState(MoveState state)
    {
        _moveStates = state;
        switch (_moveStates)
        {
            case MoveState.Run:
                break;
            case MoveState.Jump:
                break;
        }
    }

    void ChangeColorState(ColorState colorState)
    {
        _colorState = colorState;
        switch (_colorState)
        {
            case ColorState.White:
                ChangeSprite(0);
                break;
            case ColorState.Green:
                ChangeSprite(1);
                break;
            case ColorState.Red:
                ChangeSprite(2);
                break;
            case ColorState.Blue:
                ChangeSprite(3);
                break;
            case ColorState.Pink:
                ChangeSprite(4);
                break;
            case ColorState.Purple:
                ChangeSprite(5);
                break;
            case ColorState.Yellow:
                ChangeSprite(6);
                break;
            case ColorState.Cyan:
                ChangeSprite(7);
                break;
        }
    }
    
    void ChangeColor(float green, float red, float blue, float pink)
    {
        if (Input.GetButtonDown("Color 1") || Input.GetButtonDown("Color 2") || Input.GetButtonDown("Color 3") || Input.GetButtonDown("Color 4"))
        {
            green += Input.GetAxis("Color 1") * 1;
            red += Input.GetAxis("Color 2") * 5;
            blue += Input.GetAxis("Color 3") * 10;
            pink += Input.GetAxis("Color 4") * 15;
            float total = green + red + blue + pink;
            switch (total)
            {
                case 1:
                    ChangeColorState(ColorState.Green);
                    break;
                case 5:
                    ChangeColorState(ColorState.Red);
                    break;
                case 10:
                    ChangeColorState(ColorState.Blue);
                    break;
                case 15:
                    ChangeColorState(ColorState.Pink);
                    break;
                case 25:
                    ChangeColorState(ColorState.Purple);
                    break;
                case 6:
                    ChangeColorState(ColorState.Yellow);
                    break;
                case 11:
                    ChangeColorState(ColorState.Cyan);
                    break;
                default:
                    ChangeColorState(ColorState.White);
                    break;
            }
        }
    }
}
