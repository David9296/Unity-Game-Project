using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {

    // Use this for initialization
    public int playerHealth = 100;
    public float restartLevelDelay = 1f;
    private bool attacking = false;
    private float attackTimer = 0;
    private float attcCool = 0.3f;
    public int currentHealth;

    public Collider2D attackTrigger;


    private Animator anim;

    void Start()
    {
        setMaxHealth();
    }

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

        if(currentHealth <= 0)
        {
            CheckIfGameOver();
        }

        anim.SetBool("PlayerChop", attacking);
    }







    public void takeDamage(int damage)
    {
        currentHealth -= damage;
    }


    public void CheckIfGameOver()
    {
        if (currentHealth <= 0)
            GameOver();

    }

    public void setMaxHealth()
    {
        currentHealth = playerHealth;
    }


    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}
