using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool dmg;
    public bool disappear;
    public float disappearTimer = 1;
    public bool jump;
    public float jumpPower = 14;
    void Update()
    {
        Move();
        if (transform.position.x < -20)
        {
            Destroy(this.gameObject);
        }
    }

    void Move()
    {
        Vector2 position = transform.position;
        position.x -= LevelManager.instance.speedPlatform * Time.deltaTime;
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
                player.ChangeMoveState(PlayerBehaviour.MoveState.Death);
            }
            else if(jump)
            {
                player.Jump(jumpPower);
            }

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        disappearTimer -= Time.deltaTime;
        PlayerBehaviour player = collision.collider.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            if (disappearTimer < 0 && disappear)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
