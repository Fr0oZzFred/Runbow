using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailsBehaviour : MonoBehaviour
{
    public Animator animator;
    public int nbTail;
    SpriteRenderer spriteRenderer;
    public Sprite[] sprite;
    void Awake()
    {
        //spriteRenderer = transform.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void ChangeTail(int numberTail)
    {
        if( sprite[numberTail] != null)
        {
            //spriteRenderer.sprite = sprite[numberTail];
            animator.SetInteger("NbColor", numberTail);
        }
    }
}
