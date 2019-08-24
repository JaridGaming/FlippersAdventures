using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float moveInput;
    private Animator walkAnim;

    private Rigidbody rb;

    private bool faceRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        walkAnim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(moveInput * speed, rb.velocity.y);

        if(faceRight == false && moveInput > 0)
        {
            SwitchFace();
        }
        else if(faceRight == true && moveInput < 0)
        {
            SwitchFace();
        }

        if(moveInput == 0)
        {
            walkAnim.SetBool("IsWalking", false);
        }
        else
        {
            walkAnim.SetBool("IsWalking", true);
        }
    }

    void SwitchFace()
    {
        faceRight = !faceRight;
        Vector3 faces = transform.localEulerAngles;
        faces.y *= -1;
        transform.localEulerAngles = faces;
    }
}
