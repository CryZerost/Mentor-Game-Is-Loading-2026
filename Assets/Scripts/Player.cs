using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int playerHealth;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public bool isGround = false;
    public Rigidbody2D rb;
    public Vector2 move;
    public int coinScore = 0;
    public TMP_Text textScore;

    //referensi untuk animasi
    public Animator playerAnimator;
    public SpriteRenderer playerSprite;

    public GameObject bullet;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        playerHealth = 100;

        print(playerHealth);
        textScore.text = "Jumlah koin: " + coinScore; 
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAnimation();
        PlayerShoot();
        PlayerJump();
        PlayerMovement();

    }

    public void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var bulletSpawn = Instantiate(bullet, new Vector3(transform.position.x + 1f, transform.position.y, 0f), Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.one * 2);

        }
    }

    public void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isGround = false;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

    }

    public void PlayerMovement()
    {
        move.x = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(move.x * moveSpeed, rb.linearVelocity.y);
    }

    public void PlayerAnimation()
    {
        playerAnimator.SetBool("isWalking", Input.GetAxisRaw("Horizontal") != 0);

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            playerSprite.flipX = true;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            playerSprite.flipX = false;
        }

        playerAnimator.SetBool("isJumping", !isGround);
    }

    public void AddCoinScore(int value)
    {
        coinScore += value;
        textScore.text = "Jumlah koin: " + coinScore;
    }

    public void ResetCoin()
    {
        coinScore = 0;
        textScore.text = "Jumlah koin: " + coinScore;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            
            if (!isGround)
            {
                isGround = true;
            }
        }
    }

  
}
