using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{   // Frederic
    public AudioSource mainMenuTheme;
    public AudioSource goodGameOverSound;
    public AudioSource badGameOverSound;
    public AudioSource buttonSound;
    public AudioSource backButtonSound;
    public AudioSource perfectSound;
    public AudioSource goodSound;
    public AudioSource missSound;
    public AudioSource runPlayer;
    public AudioSource candy;
    public AudioSource thunder;
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
        badGameOverSound.Stop();
        goodGameOverSound.Stop();
        mainMenuTheme.Play();
    }

    public void PlayBadGameOverTheme()
    {
        badGameOverSound.Play();
    }
    public void PlayGoodGameOverTheme()
    {
        goodGameOverSound.Play();
    }
}
