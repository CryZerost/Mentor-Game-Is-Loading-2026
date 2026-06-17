using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int playerHealth;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public bool isGround = false;
    public Rigidbody2D rb;
    public Vector2 move;
    public int coinScore = 0;
    public TMP_Text textScore;




    void Start()
    {
        playerHealth = 100;

        print(playerHealth);
        textScore.text = "Jumlah koin: " + coinScore; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            playerHealth--;
            print("sisa health dari player" + playerHealth);
        }

         move.x = Input.GetAxisRaw("Horizontal");



        rb.linearVelocity = new Vector2(move.x * moveSpeed, rb.linearVelocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isGround = false;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

    }

    public void AddCoinScore(int value)
    {
        coinScore += value;
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
