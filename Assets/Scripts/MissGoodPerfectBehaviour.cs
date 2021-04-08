using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissGoodPerfectBehaviour : MonoBehaviour
{
    public int speed = 3;
    public int distance = 4;
    public float timer = 1;
    public float disappearSpeed = 0.01f;
    public GameObject[] particles;
    public bool done = false;
    Vector2 firstPos;
    SpriteRenderer rend;
    Color color = Color.white;
    private void Start()
    {
        firstPos = this.transform.position;
        GameObject tutu = Instantiate(particles[0], this.transform.position, Quaternion.identity, this.transform);
        rend = GetComponent<SpriteRenderer>();
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
            /*if(!done)
            {
                int temp = Random.Range(0, particles.Length);
                GameObject tutu = Instantiate(particles[temp], this.transform.position, Quaternion.identity, this.transform);
                done = true;
            }*/
            if (timer <0)
            {
                color.a -= disappearSpeed;
                rend.color = color;
                if (color.a <= 0)
                {
                    Destroy(this.gameObject);
                }
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
