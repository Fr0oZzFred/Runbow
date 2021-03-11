using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed = 3.0f;
    public bool dmg;
    public bool disappear;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerBehaviour player = collision.collider.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            if(dmg)
            {
                GameManager.instance.ChangeGameState(GameManager.GameState.Death);
                Debug.Log("Death");
            }
            else if (disappear)
            {
                Destroy(this.gameObject);
            }

        }
    }
}
