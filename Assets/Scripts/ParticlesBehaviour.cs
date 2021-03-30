using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesBehaviour : MonoBehaviour
{
    public int speed = 5;
    Vector2 positionTest = new Vector2(-3, 6);

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 position = transform.position;
        if (position.x > positionTest.x)
        {
            position.x -= speed * Time.deltaTime;
        }
        if(position.y < positionTest.y)
        {
            position.y += speed * 1.5f * Time.deltaTime;
        }
        if(position.x < positionTest.x && position.y > positionTest.y)
        {
            Destroy(this.gameObject);
        }
        transform.position = position;
    }

}
