using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberJack : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    private Animator walkAnim;

    public bool isWalled;
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
        speed = -speed;
        Vector3 faces = transform.localScale;
        faces.x *= -1;
        transform.localScale = faces;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            return;
        }
        GameplayStatics.DealDamage(collision.gameObject, 1);
    }
}
