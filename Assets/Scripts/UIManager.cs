using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text textScore;
    private static UIManager _instance;
    public static UIManager instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        textScore.text = "Score : " + GameManager.instance.score;
    }
}
