using UnityEngine;

public class MoveWitch : MonoBehaviour
{
    private bool isFacingRight = false;
    public Rigidbody2D rb;
    public float speed = 5f;
    public float horizontalInput;

    public float jumpPower = 5f;
    bool isGrounded = false;
    bool justJumped = false; // ← NUOVO FLAG

    public LayerMask whatisGround;
    public float checkRadius = 0.2f;
    public Transform groundCheck;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        FlipSprite();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpPower);
            isGrounded = false;
            justJumped = true; // ← Blocca il controllo a terra
            animator.SetBool("isJumping", true);
        }
    }

    void FixedUpdate()
    {
        bool overlapResult = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisGround);

        Debug.Log($"overlapResult: {overlapResult} | isGrounded: {isGrounded} | justJumped: {justJumped}");

        if (justJumped)
        {
            // Se la velocità verticale è negativa (sta cadendo), il salto è iniziato
            if (rb.linearVelocity.y < 0)
            {
                justJumped = false;
                isGrounded = overlapResult;
            }
        }
        else
        {
            isGrounded = overlapResult;
        }

        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);

        animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("yVelocity", rb.linearVelocity.y);
        animator.SetBool("isJumping", !isGrounded);

        //animator.SetBool("isJumping", !isGrounded && rb.linearVelocity.y != 0);
    }

    public void FlipSprite()
    {
        if (!isFacingRight && horizontalInput < 0f || isFacingRight && horizontalInput > 0)
        {
            isFacingRight = !isFacingRight;
            Vector2 ls = transform.localScale;
            ls.x *= -1;
            transform.localScale = ls;
        }
    }

    /*  private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }*/
}