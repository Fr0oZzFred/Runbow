using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    public float speed;
    public bool blue;
    public bool green;
    public bool red;
    public bool yellow;

    void Update()
    {
        Move();
        if(transform.position.magnitude > 30)
        {
            Destroy(this.gameObject);
        }
    }

    void Move()
    {
        Vector3 position = this.transform.position;
        position.x -= speed * Time.deltaTime;
        this.transform.position = position;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        PlayerBehaviour player = collision.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            if (blue && player.ColorStates == PlayerBehaviour.ColorState.Blue)
            {
                //Debug.Log("nice");
            }
            else if (green && player.ColorStates == PlayerBehaviour.ColorState.Green)
            {
                //Debug.Log("nice");
            }
            else if (red && player.ColorStates == PlayerBehaviour.ColorState.Red)
            {
                //Debug.Log("nice");
            }
            else if (yellow && player.ColorStates == PlayerBehaviour.ColorState.Yellow)
            {
                //Debug.Log("nice");
            }
            else
            {
                //Debug.Log("miss");
            }
        }
    }
}
