using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    public float speed;
    
    void Start()
    {

    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 position = this.transform.position;
        position.x -= speed * Time.deltaTime;
        this.transform.position = position;
    }
}
