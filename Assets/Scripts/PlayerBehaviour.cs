using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float jump = 7.0f; 
    float green = 0;
    float red = 0;
    float blue = 0;
    float pink = 0;
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
        this.Jump(jump);
        ChangeColor(green, red , blue ,pink);
        //Debug.Log(this.ColorStates);
        if (transform.position.magnitude > 4)
        {
            Destroy(this.gameObject);
        }
    }

    void ChangeMove(MoveState state)
    {
        _moveStates = state;
        switch (_moveStates)
        {
            case MoveState.Run:
                this.Run();
                //Debug.Log("Run");
                break;
            case MoveState.Jump:
                //Debug.Log("Jump");
                break;
        }
    }

    void Jump(float jump)
    {
        if(Input.GetKeyDown(KeyCode.Space) && this.MoveStates == MoveState.Run)
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
    
    void ChangeColor(float green, float red, float blue, float pink)
    {
        green += Input.GetAxis("Color 1") *1;
        red += Input.GetAxis("Color 2") * 5;
        blue += Input.GetAxis("Color 3")* 10;
        pink += Input.GetAxis("Color 4") * 15;
        float total = green + red + blue + pink;
        Debug.Log(total);
        /*switch(total)
        {

        }*/

    }
}
