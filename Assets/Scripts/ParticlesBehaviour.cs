using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesBehaviour : MonoBehaviour
{
    public int speed = 5;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 position = transform.position;
        position.x += speed * Time.deltaTime;
        transform.position = position;
    }

}
