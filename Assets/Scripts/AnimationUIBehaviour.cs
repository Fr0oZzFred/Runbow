using UnityEngine;
using UnityEngine.UI;

public class AnimationUIBehaviour : MonoBehaviour
{
    //Frederic
    Image image;
    public Sprite[] spriteRun;
    public float timer = 0.1f;
    public float speed = 100;
    int posSprite = 0;
    float time;
    void Start()
    {
        image = GetComponent<Image>();
        time = timer;
    }

    void Update()
    {
        Move();
        time -= Time.deltaTime;
        if (time < 0)
        {
            ChangeSpriteRun();
            time = timer;
        }
    }

    void ChangeSpriteRun()
    {
        if (posSprite >= spriteRun.Length)
        {
            posSprite = 0;
        }
        image.sprite = spriteRun[posSprite];
        posSprite++;
    }
    private void Move()
    {
        Vector2 pos = this.transform.position;
        pos.x += speed * Time.deltaTime;
        this.transform.position = pos;
    }
}
