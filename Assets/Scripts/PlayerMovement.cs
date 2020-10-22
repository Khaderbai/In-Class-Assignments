﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float walkingSpeed = 5f;
    public float jumpForce;
    public float runMultiplier = 2f;

    private Rigidbody2D rb;

    private float moveDirection;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = walkingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

        Move();
    }
    // Physics movements
    void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (isJumping)
        { 
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        isJumping = false;
    }
    // Process keyboard inputs
    void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        // Use Fire1 button to sprint

        if (Input.GetButtonDown("Fire1"))
        {
            moveSpeed *= runMultiplier;
        }

        // Release Fire1 to stop running

        if (Input.GetButtonUp("Fire1"))
        {
            moveSpeed = walkingSpeed;
        }
    }
    private bool IsGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;

    }

}
