using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CréditBehaviour : MonoBehaviour
{   //frederic 
    public int speed;
    public AudioSource creditTheme;
    public float time = 80;

    private void Start()
    {
        SoundManager.instance.mainMenuTheme.Stop();
        creditTheme.Play();
    }

    private void Update()
    {
        time -= Time.deltaTime;
        Move();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ScenesManager.instance.LoadMainMenu();
        }
        if(time < -40)
        {
            ScenesManager.instance.LoadMainMenu();
        }
    }

    private void Move()
    {
        if (time > 0)
        {
            Vector2 pos = this.transform.position;
            pos.y += speed * Time.deltaTime;
            this.transform.position = pos;
        }
    }
}
