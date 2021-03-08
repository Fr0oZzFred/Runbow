using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBrackgroundManager : MonoBehaviour
{
    public GameObject blue;
    public GameObject green;
    public GameObject red;
    public GameObject yellow;
    static GameObject BK;
    public int numberOfBK;
    public int selection;
    int oldBK = -1;

    private static SpawnBrackgroundManager _instance;

    public static SpawnBrackgroundManager instance
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

    void Start()
    {
        Spawn(SelectionOfColor(selection));
        oldBK = selection;
    }

    void Update()
    {

    }

    void Spawn(GameObject couleur)
    {
        Vector3 position = this.transform.position;
        BK = Instantiate(couleur, position, Quaternion.identity);
    }

    GameObject SelectionOfColor(int numberOfColor)
    {
        /*while(oldBK == selection)
        {
            selection = antiInfiniteLoop(numberOfColor);
            Debug.Log(selection);
        }*/
        switch(selection)
        {
            case 0:
                return blue;
            case 1:
                return green;
            case 2:
                return red;
            case 3:
                return yellow;
            default:
                return null;
        }
    }

    /*int antiInfiniteLoop(int numberOfColor)
    {
        int ret = Random.Range(0, numberOfColor);
        return ret;
    }*/

}
