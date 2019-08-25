﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float moveInput;
    private Animator walkAnim;

    private Rigidbody rb;

    private bool faceRight = true; // the character is facing right?


    private bool isGrounded;  // is the player on the ground
    public Transform groundCheck;   // the transform of the groundcheck
    public float checkRadius;       //the radius distance from the groundcheck
    public LayerMask whatIsGround;  //layermask

    public int extraJumps;
    public int extraJumpsValue;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody>();
        walkAnim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, whatIsGround);   //OVerlap use array, thats why use CheckSphere to check bool


        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(moveInput * speed, rb.velocity.y);

        if(faceRight == false && moveInput > 0)         // if youre facing left with no move then switch
        {
            SwitchFace();
        }
        else if(faceRight == true && moveInput < 0)     // if youre facing right with movement then switch
        {
            SwitchFace();
        }

        if(moveInput == 0)                  // basically no movement means no animsequence.
        {
            walkAnim.SetBool("IsWalking", false);
        }
        else
        {
            walkAnim.SetBool("IsWalking", true);
        }
    }

    void Update()
    {
        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            extraJumps--;
        }
        
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
        }
    }

    void SwitchFace()
    {
        faceRight = !faceRight;
        Vector3 faces = transform.localScale;           // we want to change the scale
        faces.z *= -1;
        transform.localScale = faces;
    }
}
