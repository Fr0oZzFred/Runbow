using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissGoodPerfectBehaviour : MonoBehaviour
{
    public int speed = 3;
    public int distance = 4;
    public float timer = 1;
    Vector2 firstPos;
    private void Start()
    {
        firstPos = this.transform.position;
    }
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Mathf.Abs(firstPos.y - this.transform.position.y) > distance)
        {
            timer -= Time.deltaTime;
            if (timer <0)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            Vector2 pos = this.transform.position;
            pos.y += speed * Time.deltaTime;
            this.transform.position = pos;
        }
    }
}
