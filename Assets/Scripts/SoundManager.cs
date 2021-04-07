using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource mainMenuTheme;
    public AudioSource buttonSound;
    public AudioSource backButtonSound;
    public AudioSource inGameTheme;
    public AudioSource badGameOverSound;
    public AudioSource goodGameOverSound;
    private static SoundManager _instance;
    public static SoundManager instance
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

    public void PlayButtonClip()
    {
        buttonSound.Play();
    }

    public void PlayBackButtonClip()
    {
        backButtonSound.Play();
    }
    
    public void PlayMainMenuTheme()
    {

    }
    public void InGameTheme()
    {

    }
    public void BadGameOverTheme()
    {

    }
    public void GoodGameOverTheme()
    {

    }
}
