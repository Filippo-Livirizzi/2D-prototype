using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator animator;
    public float speed = 5f;
    public float jump = 5f;
    bool isGrounded = false;
    public float horizontalInput;
    MoveWitch BasicMovement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        BasicMovement = GetComponent<MoveWitch>();
    }

    
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        FlipSprite();
    }

    void FlipSprite()
    {
        BasicMovement.FlipSprite();
    }
    
}
