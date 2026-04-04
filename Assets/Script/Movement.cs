using UnityEngine;

public class MoveWitch : MonoBehaviour
{

    private bool isFacingRight = false;
    public Rigidbody2D rb;
    public float speed = 5f;
    public float horizontalInput;

    public float jumpPower = 5f;
    bool isGrounded = false;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        FlipSprite();
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpPower);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
            
        }

    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);

        animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("yVelocity", rb.linearVelocity.y);
        animator.SetBool("isJumping", !isGrounded);

    }

    public void FlipSprite() //funzione per far girare lo sprite quando cambia direzione
    {
        if (!isFacingRight && horizontalInput < 0f || isFacingRight && horizontalInput > 0) // Se il personaggio sta guardando a destra e l'input è negativo (sinistra) o se il personaggio sta guardando a sinistra e l'input è positivo (destra)
        {
            isFacingRight = !isFacingRight; // Inverti il valore di isFacingRight
            Vector2 ls = transform.localScale; // Ottieni la scala locale dell'oggetto
            ls.x *= -1; // Inverti la scala sull'asse x per far girare lo sprite
            transform.localScale = ls; //salva la nuova scala locale dell'oggetto
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        isGrounded = true;
        animator.SetBool("isJumping", false);
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded= false;
        }
    }



}
