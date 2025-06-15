using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeed = 7f;
    public float jumpForce = 300f;

    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer spriteRenderer;

    public GroundChecker groundChecker;
    public PlayerHealth health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (health.isDead) return;

        float moveInput = Input.GetAxis("Horizontal");

        // Flip sprite
        if (moveInput > 0)
            spriteRenderer.flipX = false;
        else if (moveInput < 0)
            spriteRenderer.flipX = true;

        // Run animation
        anim.SetBool("IsRun", moveInput != 0);

        // Move character
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : moveSpeed;
        rb.velocity = new Vector2(moveInput * currentSpeed, rb.velocity.y);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }

        // Handle Jump/Fall Animations
        anim.SetBool("IsJump", !groundChecker.isGrounded && rb.velocity.y > 0.1f);
        anim.SetBool("IsFall", !groundChecker.isGrounded && rb.velocity.y < -0.1f);

    }
}
