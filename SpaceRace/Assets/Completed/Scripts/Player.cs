using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Use this for initialization
    public int playerHealth = 100;
    public float restartLevelDelay = 1f;
    private bool attacking = false;
    private float attackTimer = 0;
    private float attcCool = 0.3f;

    public Collider2D attackTrigger;


    private Animator anim;


    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("f")&&!attacking)
        {
            attacking = true;
            attackTimer = attcCool;
            attackTrigger.enabled = true;

        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }

        anim.SetBool("PlayerChop", attacking);
    }










    public void CheckIfGameOver()
    {
        if (playerHealth <= 0)
            GameOver();

    }

    public void GameOver()
    {

    }



}
