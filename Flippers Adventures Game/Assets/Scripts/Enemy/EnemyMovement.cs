using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    private Animator walkAnim;

    //do the same thing like jump mechanics, instead we use this to check if they hit a wall
    public  bool isWalled;
    public Transform wallCheck;
    public float checkRadius;
    public LayerMask whatIsWall;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        walkAnim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        isWalled = Physics.CheckSphere(wallCheck.position, checkRadius, whatIsWall);

        rb.velocity = new Vector3(-speed, rb.velocity.y);
            
        if(isWalled == true)
        {
           SwitchFace();
        }
    }
    void Update()
    {
        walkAnim.SetBool("IsWalking", true);
    }

    void SwitchFace()
    {
        speed = -speed;         // basically change the speed to vice versa
        Vector3 faces = transform.localScale;
        faces.z *= -1;
        transform.localScale = faces;
    }
}
