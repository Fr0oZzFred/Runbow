using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CréditBehaviour : MonoBehaviour
{   //frederic 
    public int speed;
    public AudioSource creditTheme;
    public GameObject tyfp;

    private void Start()
    {
        SoundManager.instance.mainMenuTheme.Stop();
        SoundManager.instance.goodGameOverSound.Stop();
        creditTheme.Play();
    }

    private void Update()
    {
        Move();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ScenesManager.instance.LoadMainMenu();
        }
        if(!creditTheme.isPlaying)
        {
            ScenesManager.instance.LoadMainMenu();
        }
    }

    private void Move()
    {
        if (tyfp.transform.position.y < Screen.height * 0.5f)
        {
            Vector2 pos = this.transform.position;
            pos.y += speed * Time.deltaTime;
            this.transform.position = pos;
        }
    }
}
