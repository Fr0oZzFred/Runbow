using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnImageBehaviour : MonoBehaviour
{
    public GameObject[] group;
    public Transform parent;
    public float timer = 10;
    float time;
    int choice = 0;
    private void Start()
    {
        Instantiate(group[choice], this.transform.position, Quaternion.identity, parent);
        choice++;
        time = timer;
    }
    private void Update()
{
        time -= Time.deltaTime;
        if(time < 0 && choice < group.Length)
        {
            Instantiate(group[choice], this.transform.position, Quaternion.identity, parent);
            choice++;
            time = timer;
        }
    }

}
