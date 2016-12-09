using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

namespace Controlling
{

    public class SimplePlatformController : NetworkBehaviour
    {

        [HideInInspector]
        public bool facingRight = true;
        [HideInInspector]
        public bool jump = false;

        public float moveForce = 400f;
        public float maxSpeed = 5f;
        public float jumpForce = 600f;
        public Transform groundCheck;


        private bool grounded = false;
        private Animator anim;
        private Rigidbody2D rb2d;
        public Camera cam;


        //Use this for initialization
        void Awake()
        {

            anim = GetComponent<Animator>();
            rb2d = GetComponent<Rigidbody2D>();
        }

        //Update is called once per frame
        void Start()
        {
            if (isLocalPlayer) return;
            cam.enabled = false;
        }

        void Update()
        {


            grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));



            if (Input.GetButtonDown("Jump") && grounded)
            {
                jump = true;
            }
        }

        void FixedUpdate()
        {

            if (!isLocalPlayer)
            {
                return;
            }

            float h = Input.GetAxis("Horizontal");

            anim.SetFloat("Speed", Mathf.Abs(h));

            if (h * rb2d.velocity.x < maxSpeed)
                rb2d.AddForce(Vector2.right * h * moveForce);

            if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
                rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

            if (h > 0 && !facingRight && isLocalPlayer)
                Flip();
            else if (h < 0 && facingRight && isLocalPlayer)
                Flip();

            if (jump && isLocalPlayer)
            {
                anim.SetTrigger("Jump");
                rb2d.AddForce(new Vector2(0f, jumpForce));
                jump = false;
            }


        }

     public   void Flip()
        {


            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

    }
}
