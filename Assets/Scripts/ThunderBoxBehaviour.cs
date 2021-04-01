using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBoxBehaviour : MonoBehaviour
{
    public bool background;
    public int color;
    public int platformType;
    public GameObject @object;
    BackgroundBehaviour backgroundObject;
    Platform platform;

    private void Awake()
    {
        backgroundObject = @object.GetComponent<BackgroundBehaviour>();
        if (backgroundObject)
        {
            backgroundObject = @object.GetComponent<BackgroundBehaviour>();
        }
        else
        {
            platform = @object.GetComponent<Platform>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBehaviour player = collision.GetComponent<PlayerBehaviour>();
        if(player != null && background)
        {
            if(backgroundObject.random)
            {
                backgroundObject.ChangeBKColorState((BackgroundBehaviour.BackGroundColorState)backgroundObject.RandomBK());
            }
            else
            {
                backgroundObject.ChangeBKColorState((BackgroundBehaviour.BackGroundColorState)color);
            }
        }
        else if(player != null)
        {
            platform.ChangePlatformState((Platform.PlatformState)platformType);
        }
    }
}
