using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControlBehaviour : MonoBehaviour
{
    public AudioSource[] audioSource;

    private float musicVolume = 1;

    private void Update()
    {
        for(int i = 0; i < audioSource.Length;i++)
        {
            audioSource[i].volume = musicVolume;
        }
        if(GameManager.GameState.Pause == GameManager.GameStates)
        {
            LevelManager.instance.inGameTheme.volume = musicVolume;
        }
    }

    public void SetVolume(float volume)
    {
        musicVolume = volume;
    }
}
