using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class SimplePlatformC : NetworkBehaviour {

    [HideInInspector]public bool facingRight = true;
    [HideInInspector]private bool isJumping = false;
    [HideInInspector]public static bool isMoving = false;
    [HideInInspector]public static bool isGrounded = false;

    public float lastx = 1;
    public float moveForce = 100f;
    public float maxSpeed = 3f;
    public float jumpForce = 200f;
    public float h;
    public float groundCheckRadius;
    public float mag;
    public Vector2 knockForce;
    public LayerMask groundLayer;
    public Transform groundCheck;
    private Animator anim;
    PlayerSync syncPos;


    private Rigidbody2D rb2d;
  //  private Animator anim;


    // Use this for initialization
    void Awake()
    {
        //  anim = GetComponent<Animator>();
        anim = gameObject.GetComponent<Animator>();
        syncPos = GetComponent<PlayerSync>();
        rb2d = GetComponent<Rigidbody2D>();
    }

  
	
	// Update is called once per frame
	    void Update () {


        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            rb2d.AddForce(new Vector2(0, jumpForce));
            isJumping = true;
            isGrounded = false;
            anim.SetBool("PlayerJump", isJumping);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
            //isJumping = false;
            isGrounded = true;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy" && !isGrounded && Player.attacking == false || coll.gameObject.tag == "Boss" && !isGrounded  && Player.attacking ==false)
        {
            knockForce = transform.position - coll.transform.position;
            knockForce.Normalize();
            rb2d.AddForce(knockForce * 1);
        }
        else if (coll.gameObject.tag == "Enemy" && isGrounded && Player.attacking == false  || coll.gameObject.tag == "Boss" && isGrounded && Player.attacking == false)
        {
            knockForce = transform.position - coll.transform.position;
            knockForce.Normalize();
            rb2d.AddForce(knockForce * mag);
        }
    }
            
        
    

    void FixedUpdate()
    {

       

        if (!isLocalPlayer)
        {
            return;
        }


        h = Input.GetAxisRaw("Horizontal");
        
        isMoving = (Mathf.Abs(h) > 0);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


        if ((h > 0 && facingRight) || (h < 0 && !facingRight))
        {
        
            facingRight = !facingRight;
            syncPos.CmdFlip(facingRight);


        }

        if (isMoving && !Player.attacking)
        {
            movement();
            
         
          //  anim.SetBool("isRunning", isMoving);
       }
        else if (!isMoving)
        {
            anim.SetBool("isRunning", false);
        }

     }



    void movement()
    {
        anim = GetComponent<Animator>();

        anim.SetBool("isRunning", true);

        if (h * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * h * moveForce);

        }
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }

        if (h==0)
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
      
    }

}


