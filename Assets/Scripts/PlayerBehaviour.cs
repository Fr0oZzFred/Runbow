﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    
    public enum Move
    {
        Jump,
        Run,
        Death,
    }
    private Move _move;
    public Move Moves
    {
        get
        {
            return _move;
        }
    }

    public enum ColorState
    {
        Blue,
        Green,
        Red,
        Yellow,
    }
    private ColorState _color;
    public ColorState color
    {
        get
        {
            return _color;
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
            Jump();
        }
        ChangeColor();
    }

    void ChangeMove(Move state)
    {
        _move = state;
        switch (_move)
        {
            case Move.Run:
                this.Run();
                Debug.Log("Run");
                break;
            case Move.Jump:
                this.Jump();
                Debug.Log("Jump");
                break;
        }
    }

    void Jump()
    {
        rigidbody2d.velocity = new Vector2(0.0f, 7.0f);
    }

    public void OnCollisionEnter2d(Collision collider)
    {
        Run();
    }

    void Run()
    {
        Debug.Log("Running");
    }

    void ChangeColorState(ColorState colorState)
    {
        _color = colorState;
        switch (_color)
        {
            case ColorState.Blue:
                Debug.Log("Blue");
                break;
            case ColorState.Green:
                Debug.Log("Green");
                break;
            case ColorState.Red:
                Debug.Log("Red");
                break;
            case ColorState.Yellow:
                Debug.Log("Yellow");
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
