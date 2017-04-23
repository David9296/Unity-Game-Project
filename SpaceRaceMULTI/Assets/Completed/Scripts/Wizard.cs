using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour {

    public float fireRate;
    public bool facingLeft;

    public float moveSpeed;

    private Rigidbody2D rb2d;
    public Transform GroundCheck;
    private bool hittingWall;
    public float wallCheckRadius;

    private Player theplayer;
    public float range;
    public LayerMask playerLayer;
    public bool inRange;

    public GameObject shot;
    public Transform shotPosition;
    public float speed;
    public int numberOfShots;
    private float nextFire;
 


    void Awake()
    {
        theplayer = FindObjectOfType<Player>();
        rb2d = GetComponent<Rigidbody2D>();
      
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        inRange = Physics2D.OverlapCircle(transform.position, range, playerLayer);
       
        Movement();

       
    }



    void Movement() {

        hittingWall = Physics2D.OverlapCircle(GroundCheck.position, wallCheckRadius);

        if (hittingWall)
        {


            facingLeft = !facingLeft;
            Flip();
        }

        if (facingLeft && !inRange)
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        }
        else if (!facingLeft &&!inRange)
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);


        }

        if (inRange)
        {

            rb2d.velocity = Vector3.zero;
            shoot();
   
        }


    }



    void shoot()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            for(int i = 0; i <numberOfShots; i++)
            {
                GameObject shots = (GameObject)Instantiate(shot, shotPosition.transform.position, shot.transform.rotation);
                shots.GetComponent<Rigidbody2D>().velocity =(theplayer.transform.position -transform.position).normalized*speed;
            }
        }

    }

    public void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

  



}
