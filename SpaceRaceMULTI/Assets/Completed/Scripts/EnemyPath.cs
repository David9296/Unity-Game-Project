using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour {

    public bool facingLeft;

    public float moveSpeed;
   
    private Rigidbody2D rb2d;
    public Transform GroundCheck;
    private bool hittingWall;
    public float wallCheckRadius;

   

    // Use this for initialization
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Movement();
       
    }

    

    void Movement()
    {
        hittingWall = Physics2D.OverlapCircle(GroundCheck.position, wallCheckRadius); //Draws Circke to check for  Collisions
        if (hittingWall)
        {


            facingLeft = !facingLeft;
            Flip();
        }

        if (facingLeft)
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        }
        else if (!facingLeft)
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);


        }
    }


    public void Flip()
    {


      
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    

}
