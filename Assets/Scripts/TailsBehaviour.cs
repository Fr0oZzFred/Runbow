using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailsBehaviour : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] sprite;
    void Awake()
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
    }

    public void ChangeTail(int numberTail)
    {
        if( sprite[numberTail] != null)
        {
            spriteRenderer.sprite = sprite[numberTail];
        }
    }
}
