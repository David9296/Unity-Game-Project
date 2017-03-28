using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private bool moving;
    public float speed;
    public float movY;
    public float movX;
    public int maxHealth = 40;
    public int currHealth ;
    private Vector2 mov;
    public float betweenMovesTime;
    private float betweenMovesCount;
    public float toMoveTime;
    private float toMoveCount;
    private Rigidbody2D rig;
    public float maxSpeed;
    public bool flips;
    public int damage;

    // Use this for initialization
    void Start () {

        currHealth = maxHealth;
        rig = GetComponent<Rigidbody2D>();

        betweenMovesCount = betweenMovesTime;
        toMoveCount = toMoveTime;

    }
	
	// Update is called once per frame
	void Update () {
		
        if (currHealth<=0)
        {
            Destroy(gameObject);
        }
	}


    private void FixedUpdate()
    {
       
            movement();
     
    }

    public void Damage(int damage)
    {
        currHealth -= damage;
    }

    public void movement()
    {
        rig = GetComponent<Rigidbody2D>();
       

        if (moving)
        {
            toMoveCount -= Time.fixedDeltaTime;
            rig.velocity = mov * speed * Time.deltaTime;
            if (toMoveCount < 0f)
            {
                mov = new Vector2(movX, mov.y);
                moving = false;
                betweenMovesCount = betweenMovesTime;
                rig.velocity = mov * speed * Time.deltaTime;
            }
        }
        else
        {
            betweenMovesCount -= Time.fixedDeltaTime;

            if (betweenMovesCount < 0f)
            {
                if (flips)
                {
                    switchSide();
                }
                moving = true;
                toMoveCount = toMoveTime;
                if ((mov.x > 0 && mov.x < maxSpeed) || (mov.x < 0 && mov.x > -maxSpeed))
                {
                    mov = new Vector2(mov.x * movX, -movY);
                }
                else
                {
                    mov = new Vector2(movX, -mov.y);
                    if (flips)
                    {
                        mov.x = -mov.x * 1.2f;
                        mov = new Vector2(mov.x, 3);
                    }
                }
                rig.velocity = mov * speed * Time.deltaTime;

            }

        }
    }

    public void switchSide()
    {
        if (mov.x > 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        else if (mov.x < 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        //mov = new Vector2(-mov.x, -mov.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().takeDamage(damage);
        }
    }

}
