using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float jump = 7.0f;
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
        Blue,
        Green,
        Red,
        Yellow,
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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.Jump();
        }
        ChangeColor();
        //Debug.Log(this.ColorStates);
    }

    void ChangeMove(MoveState state)
    {
        _moveStates = state;
        switch (_moveStates)
        {
            case MoveState.Run:
                this.Run();
                Debug.Log("Run");
                break;
            case MoveState.Jump:
                Debug.Log("Jump");
                break;
        }
    }

    void Jump()
    {
        if(this.MoveStates == MoveState.Run)
        {
            rigidbody2d.velocity = new Vector2(0.0f, jump);
            ChangeMove(MoveState.Jump);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Platform platform = collision.collider.GetComponent<Platform>();
        if( platform != null)
        {
            ChangeMove(MoveState.Run);
        }
    }

    void Run()
    {
        
    }

    void ChangeColorState(ColorState colorState)
    {
        _colorState = colorState;
        switch (_colorState)
        {
            case ColorState.Blue:
                break;
            case ColorState.Green:
                break;
            case ColorState.Red:
                break;
            case ColorState.Yellow:
                break;
        }
    }
    
    void ChangeColor()
    {
        float blue = Input.GetAxis("Blue");
        float green = Input.GetAxis("Green");
        float red = Input.GetAxis("Red");
        float yellow = Input.GetAxis("Yellow");
        if(blue == 1)
        {
            ChangeColorState(ColorState.Blue);
        }
        else if(green == 1)
        {
            ChangeColorState(ColorState.Green);
        }
        else if (red == 1)
        {
            ChangeColorState(ColorState.Red);
        }
        else if (yellow == 1)
        {
            ChangeColorState(ColorState.Yellow);
        }
    }
}
