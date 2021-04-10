using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesBehaviour : MonoBehaviour
{
    public bool star;
    public float speed = 2f;
    public float time = 5;
    Vector2 positionUI;
    Vector2 position;

    private void Start()
    {
        if(star)
        {
            positionUI = Camera.main.ScreenToWorldPoint(UIManager.instance.starUI.transform.position);
        }
        else
        {
            positionUI = Camera.main.ScreenToWorldPoint(UIManager.instance.candyUI.transform.position);
        }
    }
    void Update()
    {
        Move();
        time -= Time.deltaTime;
        if(time < 0 || GameManager.GameStates == GameManager.GameState.Death || GameManager.GameStates == GameManager.GameState.Pause)
        {
            Destroy(this.gameObject);
        }
    }

    private void Move()
    {
        position = transform.position;
        float newSpeed = (positionUI.x - position.x) * speed;
        MoveAxisX(newSpeed);
        newSpeed = (positionUI.y - position.y) * speed;
        MoveAxisY(newSpeed);
        transform.position = position;
    }
    void MoveAxisX(float newSpeed)
    {
        if(position.x < positionUI.x)
        {
            position.x += Mathf.Abs(newSpeed) * Time.deltaTime;
        }
        else
        {
            position.x -= Mathf.Abs(newSpeed) * Time.deltaTime;
        }
    }

    void MoveAxisY(float newSpeed)
    {
        if (position.y < positionUI.y)
        {
            position.y += Mathf.Abs(newSpeed) * Time.deltaTime;
        }
        else
        {
            position.y -= Mathf.Abs(newSpeed) * Time.deltaTime;
        }
    }
}
