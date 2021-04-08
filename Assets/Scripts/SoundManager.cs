using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource mainMenuTheme;
    public AudioSource inGameTheme;
    public AudioSource goodGameOverSound;
    public AudioSource badGameOverSound;
    public AudioSource buttonSound;
    public AudioSource backButtonSound;
    public AudioSource perfectSound;
    public AudioSource goodSound;
    public AudioSource missSound;
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
        inGameTheme.Stop();
        badGameOverSound.Stop();
        goodGameOverSound.Stop();
        mainMenuTheme.Play();
    }
    public void PlayInGameTheme()
    {
        mainMenuTheme.Stop();
        badGameOverSound.Stop();
        goodGameOverSound.Stop();
        inGameTheme.Play();
    }

    public void PlayBadGameOverTheme()
    {
        inGameTheme.Stop();
        badGameOverSound.Play();
    }
    public void PlayGoodGameOverTheme()
    {
        inGameTheme.Stop();
        goodGameOverSound.Play();
    }
}
