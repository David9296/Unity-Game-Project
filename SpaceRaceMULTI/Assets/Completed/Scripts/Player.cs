using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;


public class Player : NetworkBehaviour {

    // Use this for initialization
    public int playerHealth = 100;
    public float restartLevelDelay = 1f;
    public static bool attacking = false;
    private float attackTimer = 0;
    private float attcCool = 0.5f;
    public int currentHealth;
    private bool ishurt;
    public GameObject respawn;
    public Transform player;
    public GameObject blood;
    private NetworkStartPosition[] spawner;
  

    public int score;
    Text scoreText;

    Text health;

    public Collider2D attackTrigger;
    private Rigidbody2D rb2d;

    private Animator anim;

    void Start()
    {
        setMaxHealth();
        health = GameObject.FindGameObjectWithTag("HealthNumber").GetComponent<Text>();
        scoreText = GameObject.FindGameObjectWithTag("ScoreNumber").GetComponent<Text>();
        respawn = GameObject.FindGameObjectWithTag("Respawn");

        if (isLocalPlayer)
        {
            spawner = FindObjectsOfType<NetworkStartPosition>();
        }
     
    }

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        updateScore();
        updateHealth();

        if (!isLocalPlayer)
        {
            return;
        }

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

       

        anim.SetBool("playerHit", attacking);
    }


    void FixedUpdate ()
   
    {
        if (currentHealth <= 0)
        {
            CheckIfGameOver();
        }
    }






    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        Instantiate(blood, transform.position, Quaternion.identity);
        anim.SetBool("playerHurt", true);
     


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
        rb2d.MovePosition(respawn.transform.position);
        currentHealth = playerHealth;
        RpcRespawn();
        
    }

   
    public void updateHealth()
    {
        health.text = currentHealth.ToString();
    }

    public void addScore(int newScore)
    {
        score += newScore;
        updateScore();
    }

    public void updateScore()
    {

        scoreText.text = score.ToString();
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            Vector3 spawnPoint = Vector3.zero;
            if(spawner!=null && spawner.Length > 0)
            {
                spawnPoint = spawner[Random.Range(0, spawner.Length)].transform.position;
            }

            transform.position = spawnPoint;
        }
    }
}
