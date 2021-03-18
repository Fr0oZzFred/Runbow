using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagersBehaviour : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("MainMenu");
    }
}
