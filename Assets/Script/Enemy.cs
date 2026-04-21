using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform target;
    Vector2 moveDirection;
    float speed = 3f;

    Animator anim;
    SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;

            //flip sprite
            if (direction.x > 0)
            {
                sr.flipX = false;
            }
            else if (direction.x < 0)
            {
                sr.flipX = true;
            }
            anim.SetFloat("xVelocity", Mathf.Abs(moveDirection.x));
           // anim.SetFloat("yVelocity", moveDirection.y);
            //  anim.SetBool("isMoving", moveDirection.magnitude > 0);

        }


    }
            private void FixedUpdate()
        {
            if (target)
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
            else
                rb.linearVelocity = Vector2.zero;

        }

        public void StartChasing()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
