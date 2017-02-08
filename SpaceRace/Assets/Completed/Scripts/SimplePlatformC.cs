using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatformC : MonoBehaviour {

    [HideInInspector]public bool facingRight = true;
    [HideInInspector]private bool isJumping = false;

    public float moveForce = 265f;
    public float maxSpeed = 3f;
    public float jumpForce = 200f;


  

    private Rigidbody2D rb2d;
    private Animator anim;


    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();

        rb2d = GetComponent<Rigidbody2D>();
    }

  
	
	// Update is called once per frame
	    void Update () {

            if (Input.GetButtonDown("Jump") && !isJumping)
            {
                rb2d.AddForce(new Vector2(0, jumpForce));
                   isJumping = true;
                }
             }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
            isJumping = false;
    }

    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

     }


      public void Flip()
    {


        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}

//Double Jump not good
