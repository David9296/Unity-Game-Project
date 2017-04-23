using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMovement : MonoBehaviour {

    public bool shadowBoss;

    public float moveSpeed;
    public float punchRange;
    public float shootRange;
    public float nextFire;
    public int numberOfshots;
    public float fireRate;
    public float shotSpeed;

    public bool facingLeft;
    public bool hittingEdge;
    public bool hittingWall;
    public bool punching;
    public bool shooting;
    public float edgeRadius;
    public bool isPunching;

    private Player theplayer;
    public LayerMask playerLayer;
    public Transform edgeCheck;
    public GameObject shot;
    public Transform shotPosition;

    public Collider2D attackTrigger;
    private Rigidbody2D rb2d;
    private Animator anim;



    void Awake()
    {
        theplayer = FindObjectOfType<Player>();
        rb2d = GetComponent<Rigidbody2D>();
        attackTrigger.enabled = false;
        anim = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Movement();
        Punch();
        Shoot();
	}

    void Movement()
    {

        anim.SetBool("isRunning", true);
        hittingWall = Physics2D.OverlapCircle(edgeCheck.position, edgeRadius);

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

    void Punch()
    {
        punching = Physics2D.OverlapCircle(attackTrigger.transform.position, punchRange, playerLayer);

        if (punching)
        {
            isPunching = true;
        }


        if (isPunching)
        {

            anim.SetBool("shadowPunch", true);
            attackTrigger.enabled = true;
            isPunching = false;
            rb2d.velocity = Vector3.zero;
            anim.SetBool("isRunning", false);
        }
        else if (!isPunching)
        {

            attackTrigger.enabled = false;
        }


    }

    void Shoot()
    {
        shooting = Physics2D.OverlapCircle(transform.position, shootRange, playerLayer);
        
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            for(int i=0;i<numberOfshots; i++)
            {
                GameObject shots = (GameObject)Instantiate(shot, shotPosition.transform.position, shot.transform.rotation);
                shots.GetComponent<Rigidbody2D>().velocity = (theplayer.transform.position - transform.position).normalized * shotSpeed;
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
    