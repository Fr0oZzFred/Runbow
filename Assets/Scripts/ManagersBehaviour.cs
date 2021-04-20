using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ManagersBehaviour : MonoBehaviour
{   // Frederic
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
        GameManager.instance.ChangeGameState(GameManager.GameState.MainMenu);
        SceneManager.LoadScene("MainMenu");
    }
}
