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
    public float time;
    public float timingPerfect = 2;
    public float timingGood = 5;

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
                VerifTiming();
            }
            else if (green && player.ColorStates == PlayerBehaviour.ColorState.Green)
            {
                VerifTiming();
            }
            else if (red && player.ColorStates == PlayerBehaviour.ColorState.Red)
            {
                VerifTiming();
            }
            else if (yellow && player.ColorStates == PlayerBehaviour.ColorState.Yellow)
            {
                VerifTiming();
            }
            else
            {
                time += Time.deltaTime;
                if (time > timingGood)
                {
                    time = 0;
                    Debug.Log("miss");
                }
            }
        }
    }

    void VerifTiming()
    {
        if (time < 2)
        {
            Debug.Log(timingPerfect);
            Debug.Log("perfect");
        }
        else if (time < 5)
        {
            Debug.Log(timingGood);
            Debug.Log("good");
        }
    }
}
