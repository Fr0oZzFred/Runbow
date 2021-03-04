using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    
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

    void Start()
    {
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
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
}
