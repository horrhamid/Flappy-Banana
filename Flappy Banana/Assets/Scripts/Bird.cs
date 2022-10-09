using UnityEngine;


public class Bird : MonoBehaviour       
{
    
    Rigidbody2D rb;
    public float speed;

    //refrences
    public GameManager gameManager;
    public Score score;
    public Sprite birdDied;
    public ColumnSpawner columnSpawner;
    public Animator birdParentAnim;
    public Animator getReadyAnim;
    

    SpriteRenderer sp;
    Animator anim;

    int angle;
    int maxAngle = 20;
    int minAngle = -90;

    bool touchGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && 
            GameManager.gameOver == false &&
            GameManager.gameIsPaused == false)
        {
            if(GameManager.gameHasStarted == false)
            {
                Flap();
                birdParentAnim.enabled = false;

                getReadyAnim.SetTrigger("FadeOut");

            }
            else
            {
                Flap();
            }
            
        }

        BirdRotation();
         


    }

    public void StartGame()
    {
        columnSpawner.InstantiateColumn();
        gameManager.GameHasStarted();
    }

    void Flap()
    {
        AudioManager.audiomanager.Play("flap");
        rb.velocity = Vector2.zero;
        rb.velocity = new Vector2(rb.velocity.x, speed);
    }

    void BirdRotation()
    {
        if (rb.velocity.y > 0)
        {
            rb.gravityScale = 0.8f;
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = 0.6f;

            if (rb.velocity.y < -1.3f)
            {
                if (angle >= minAngle)
                {
                    angle = angle - 3;
                }
            }
        }

        if(touchGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Column"))
        {
            score.Scored();
            AudioManager.audiomanager.Play("point");

        }
        else if (collision.CompareTag("Pipe"))
        {
            AudioManager.audiomanager.Play("hit");
            // game over
            gameManager.GameOver();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(GameManager.gameOver == false)
            {
                AudioManager.audiomanager.Play("hit");
                //game over
                gameManager.GameOver();
                BirdGameOver();
            }
            else
            {
                // gameover the bird
                BirdGameOver();
            }
        }
    }

    void BirdGameOver()
    {
        touchGround = true;
        anim.enabled = false;
        sp.sprite = birdDied;
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }
}






