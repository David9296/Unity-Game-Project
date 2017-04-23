using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidBoss : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D rb2d;
    public Transform GroundCheck;
    public Transform WallCheck;
    public float wallCheckRadius;
    public bool goingUp;
    public bool hittingGround;
    public bool hittingWall;

    public GameObject shot;
    public Transform shotPosition;
    private Animator anim;

    public float speed;
    public int numberOfShots;
    private float nextFire;
    public float fireRate;
    public LayerMask groundLayer;
    public LayerMask edgeLayer;


    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       // groundLayer = GetComponent<LayerMask>();
     //   edgeLayer = GetComponent<LayerMask>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {


        
        Shoot();
	}

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        hittingWall = Physics2D.OverlapCircle(WallCheck.position, wallCheckRadius,edgeLayer);
        hittingGround = Physics2D.OverlapCircle(GroundCheck.position, wallCheckRadius,groundLayer);

        if (hittingWall)
        {
            goingUp = !goingUp;
        }

        if (hittingGround)
        {
            goingUp = true;
        }

        if (goingUp)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, moveSpeed);
        }

        else if (!goingUp)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, -moveSpeed);
        }
    }

    void Shoot()
    {
        //anim.SetBool("isShooting", false);

        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            anim.SetBool("isShooting", true);
            for(int i = 0; i<numberOfShots; i++)
            {
                GameObject shots = (GameObject)Instantiate(shot, shotPosition.transform.position, shot.transform.rotation);
                shots.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(0f, -1f), Random.Range(-0.6f, 0.6f), 0) * speed;
            }
        }   
    }

}
