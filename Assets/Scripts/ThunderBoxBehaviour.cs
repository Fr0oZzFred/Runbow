using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBoxBehaviour : MonoBehaviour
{
    public int color;
    public GameObject backgroundObject;
    BackgroundBehaviour background;

    private void Start()
    {
        background = backgroundObject.GetComponent<BackgroundBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBehaviour player = collision.GetComponent<PlayerBehaviour>();
        if( player != null)
        {
            if(background.random)
            {
                background.ChangeBKColorState((BackgroundBehaviour.BackGroundColorState)background.RandomBK());
            }
            else
            {
                background.ChangeBKColorState((BackgroundBehaviour.BackGroundColorState)color);
            }
        }
    }
}
