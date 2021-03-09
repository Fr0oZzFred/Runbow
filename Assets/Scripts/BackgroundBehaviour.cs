using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    public float speed;
    bool done = false;

    void Start()
    {

    }

    void Update()
    {
        Move();
        if(transform.position.magnitude < 10 && !done )
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
}
