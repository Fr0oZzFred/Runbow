using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagersBehaviour : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        //GameManager.instance.SaveData();
        //GameManager.instance.LoadData();
        SceneManager.LoadScene("MainMenu");
    }
}
