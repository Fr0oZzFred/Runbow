using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagersBehaviour : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
