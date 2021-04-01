using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesBehaviour : MonoBehaviour
{
    public bool star;
    public float speed = 2f;
    public float time = 5;
    Vector2 positionTest;
    Vector2 position;

    private void Start()
    {
        if(star)
        {
            positionTest = Camera.main.ScreenToWorldPoint(UIManager.instance.starUI.transform.position);
        }
        else
        {
            positionTest = Camera.main.ScreenToWorldPoint(UIManager.instance.candyUI.transform.position);
        }
    }
    void Update()
    {
        Move();
        time -= Time.deltaTime;
        if(time < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void Move()
    {
        position = transform.position;
        float newSpeed = (positionTest.x - position.x) * speed;
        MoveAxisX(newSpeed);
        newSpeed = (positionTest.y - position.y) * speed;
        MoveAxisY(newSpeed);
        transform.position = position;
    }
    void MoveAxisX(float newSpeed)
    {
        if(position.x < positionTest.x)
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
        if (position.y < positionTest.y)
        {
            position.y += Mathf.Abs(newSpeed) * Time.deltaTime;
        }
        else
        {
            position.y -= Mathf.Abs(newSpeed) * Time.deltaTime;
        }
    }
}
