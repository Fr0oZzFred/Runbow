using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPerfect : MonoBehaviour
{
    public bool touche = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public float speed = 3.0f;

    void Start()
    {

    }

    void Update()
    {
        Move();
        if (transform.position.magnitude > 30)
        {
            Destroy(this.gameObject);
        }
    }

    void Move()
    {
        Vector2 position = transform.position;
        position.x = position.x - speed * Time.deltaTime;
        transform.position = position;
    }
}
