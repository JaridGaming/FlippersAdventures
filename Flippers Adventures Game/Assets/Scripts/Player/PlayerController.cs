using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float moveInput;
    private Animator walkAnim;
    private Animator swordAnim;
    private Animator shieldAnim;

    private Rigidbody rb;

    private bool faceRight = true; // the character is facing right?


    private bool isGrounded;  // is the player on the ground
    public Transform groundCheck;   // the transform of the groundcheck
    public float checkRadius;       //the radius distance from the groundcheck
    public LayerMask whatIsGround;  //layermask

    private int extraJumps;
    public int extraJumpsValue;

    private float timeToAttack;
    public float timeToAttackValue;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public int slashDmg;
    public float attackRange;

    private float timeToShield;
    public float timeToShieldValue;

    public float timeToJumpBuffValue;
    public float timeToJumpBuff;

    void Start()
    {
        timeToJumpBuff = timeToJumpBuffValue;
        extraJumps = extraJumpsValue;
        timeToAttack = timeToAttackValue;
        timeToShield = timeToShieldValue;
        rb = GetComponent<Rigidbody>();
        walkAnim = GetComponent<Animator>();
        swordAnim = GetComponent<Animator>();
        shieldAnim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, whatIsGround);   //Overlap use array, thats why use CheckSphere to check bool


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

        WalkState();
    }

    void Update()
    {
        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            if(timeToJumpBuff < timeToJumpBuffValue)
            {
                rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);   // this one is if the lumberjack is killed, then change the amount of jump
                Invoke("Reset", 5);
            }
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);       // add jump POWERRR to it
            extraJumps--;
        }
 
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            if (timeToJumpBuff < timeToJumpBuffValue)
            {
                rb.AddForce(new Vector3(0, 3, 0), ForceMode.Impulse);
            }
            rb.AddForce(new Vector3(0, 1, 0), ForceMode.Impulse);
        }

        SwordState();
        ShieldState();

    }

    void SwitchFace()
    {
        faceRight = !faceRight;
        Vector3 faces = transform.localScale;           // we want to change the scale
        faces.z *= -1;
        transform.localScale = faces;
    }

    void WalkState()
    {
        if (moveInput == 0)                  // basically no movement means no animsequence.
        {
            walkAnim.SetBool("IsWalking", false);
        }
        else
        {
            walkAnim.SetBool("IsWalking", true);
        }
    }

    void SwordState()
    {
        if (Input.GetMouseButtonDown(0) && timeToAttack <= 0)
        {
            swordAnim.SetBool("IsAttacking", true);
            timeToAttack = timeToAttackValue;

            Collider[] enemiesToDmg = Physics.OverlapSphere(attackPos.position, attackRange, whatIsEnemies);
            for(int i = 0; i< enemiesToDmg.Length; i++)
            {
                                           // collider.gameObject  ==> since this collider is from gameobject
                GameplayStatics.DealDamage(enemiesToDmg[i].gameObject, slashDmg);
                Debug.Log("HIt");

                if(enemiesToDmg[i].gameObject.tag == "LumberJack")  // check if the enemy is LumberJack then we can do jumpbuff;
                {
                    timeToJumpBuff = 0;
                }
            }


        }
        else
        {
            swordAnim.SetBool("IsAttacking", false);
            timeToAttack -= Time.deltaTime;
        }
    }

    //knockback on the shield
    void ShieldState()
    {
        if (Input.GetMouseButton(1) && timeToShield <= 0)
        {
            shieldAnim.SetBool("IsBlocking", true);
            timeToShield = timeToShieldValue;
        }
        else
        {
            shieldAnim.SetBool("IsBlocking", false);
            timeToShield -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    private void Reset()        // basically this start when player get jump buff
    {
        timeToJumpBuff = timeToJumpBuffValue;
    }
}
