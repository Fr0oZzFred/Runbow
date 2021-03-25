using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailsBehaviour : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] sprite;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeTail(int numberTail)
    {
        spriteRenderer.sprite = sprite[numberTail];
    }
}
