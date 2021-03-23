using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesBehaviour : MonoBehaviour
{
    public int score;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 position = transform.position;
        position.x -= LevelManager.instance.speedPlatform * Time.deltaTime;
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBehaviour player = collision.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            GameManager.instance.addCandy(score);
            Destroy(this.gameObject);
        }
    }
}
