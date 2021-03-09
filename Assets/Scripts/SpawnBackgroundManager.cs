using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBackgroundManager : MonoBehaviour
{
    public GameObject blue;
    public GameObject green;
    public GameObject red;
    public GameObject yellow;
    public GameObject BK;
    public int numberOfBK;
    public int selection;
    int oldBK = -1;

    private static SpawnBackgroundManager _instance;
    public static SpawnBackgroundManager instance
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

    public void Spawn(GameObject couleur)
    {
        Vector3 position = this.transform.position;
        BK = Instantiate(couleur, position, Quaternion.identity);
    }

    public GameObject SelectionOfColor(int numberOfColor)
    {
        while(oldBK == selection)
        {
            selection = AntiInfiniteLoop(numberOfColor);
        }
        oldBK = selection;
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

    int AntiInfiniteLoop(int numberOfColor)
    {
        int ret = Random.Range(0, numberOfColor);
        return ret;
    }

}
