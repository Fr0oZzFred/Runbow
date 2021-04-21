using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{    //pas utilisé mais garder au cas où, Cedric
    private static SpawnManager _instance;
    public static SpawnManager instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    public GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawning()
    {
        float scale = Random.Range(0.3f, 1f);
        float smooth = 2.0f;
        Vector3 newScale = new Vector3(scale, 0.42f, 1f); // Les dimensions souhaités
        transform.localScale = Vector3.Lerp(transform.localScale, newScale, Time.deltaTime * smooth);
        Instantiate(platform, this.transform.position, Quaternion.identity);
    }
}
