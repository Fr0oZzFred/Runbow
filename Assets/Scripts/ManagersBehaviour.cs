using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ManagersBehaviour : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        string path = Application.persistentDataPath + "/GameManager.data";
        if (File.Exists(path))
        {
            GameManager.instance.LoadData();
        }
        else
        {
            GameManager.instance.SaveData();
        }
        SceneManager.LoadScene("MainMenu");
    }
}
