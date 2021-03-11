using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    public float speed;
    bool done = false;
    public bool blue;
    public bool green;
    public bool red;
    public bool yellow;

    void Start()
    {

    }

    void Update()
    {
        Move();
        if(transform.position.magnitude < 5 && !done )
        {
            SpawnBackgroundManager.instance.Spawn(SpawnBackgroundManager.instance.SelectionOfColor(SpawnBackgroundManager.instance.numberOfBK));
            done = true;
        }
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("touché");
        PlayerBehaviour player = collision.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            /*GameObject realPlayer = GameObject.Find("Player");
            if (blue && realPlayer.color == PlayerBehaviour.ColorState.Blue)
            {
                Debug.Log("tata");
            }*/
        }
    }
}
