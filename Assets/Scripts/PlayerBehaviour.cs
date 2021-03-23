using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float jumpPower = 7.0f;
    public int life = 2;
    public GameObject star;
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
    void Awake()
    {
        Vector2 position = new Vector2(0, 0);
        this.transform.position = position;
    }
    void Start()
    {
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        this.enabled = true;
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
        //GameObject star1 = Instantiate(star, this.transform.position, Quaternion.identity);
    }

    void VerifDeath()
    {
        if (transform.position.magnitude > 7 || life < 0)
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
                break;
            case ColorState.Green:
                break;
            case ColorState.Red:
                break;
            case ColorState.Blue:
                break;
            case ColorState.Pink:
                break;
            case ColorState.Purple:
                break;
            case ColorState.Yellow:
                break;
            case ColorState.Cyan:
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
