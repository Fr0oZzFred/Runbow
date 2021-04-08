using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool thunder;
    public int platformType;
    public float disappearSpeed = 0.1f;
    public float jumpPower = 10;
    public GameObject thunderBox;
    SpriteRenderer rend;
    public Sprite[] platformSprite;
    Color color = Color.white;
    public enum PlatformState
    {
        Normal,
        Pics,
        Disappear,
        Jump,
    }
    private PlatformState __platformState;
    public PlatformState PlatformStates
    {
        get
        {
            return __platformState;
        }
    }
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        ChangePlatformState((PlatformState)platformType);
        if(thunder)
        {
            thunderBox.SetActive(true);
        }
    }

    void Update()
    {
        Move();
        if (transform.position.x < -20)
        {
            Destroy(this.gameObject);
        }
    }

    void Move()
    {
        Vector2 position = transform.position;
        position.x -= LevelManager.instance.speedPlatform * Time.deltaTime;
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerBehaviour player = collision.collider.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            if(PlatformStates == PlatformState.Pics)
            {
                GameManager.instance.ChangeGameState(GameManager.GameState.Death);
                player.ChangeMoveState(PlayerBehaviour.MoveState.Death);
            }
            else if(PlatformStates == PlatformState.Jump)
            {
                Animator boing = GetComponent<Animator>();
                boing.SetTrigger("Bond");
                player.Jump(jumpPower);
            }

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerBehaviour player = collision.collider.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            if (PlatformStates == PlatformState.Disappear)
            {
                color.a -= disappearSpeed;
                rend.color = color;
                if (color.a <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

    void ChangePlatformSprite(int spriteInt)
    {
        rend.sprite = platformSprite[spriteInt];
    }

    public void ChangePlatformState(PlatformState platformState)
    {
        __platformState = platformState;
        switch(__platformState)
        {
            case PlatformState.Normal:
                ChangePlatformSprite(0);
                break;
            case PlatformState.Pics:
                ChangePlatformSprite(1);
                break;
            case PlatformState.Disappear:
                ChangePlatformSprite(2);
                break;
            case PlatformState.Jump:
                ChangePlatformSprite(3);
                break;
        }
    }
}
