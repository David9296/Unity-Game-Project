using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Enemy : NetworkBehaviour {

    
    
   
    public int maxHealth = 40;

    
    public int currHealth ;
    public GameObject blood; 
    
    public int damage;
    private Animator anim;
    public Player player;

    // Use this for initialization
    void Start () {

        currHealth = maxHealth;
        player = FindObjectOfType<Player>();
        anim = gameObject.GetComponent<Animator>();

        

    }
	
	// Update is called once per frame
	void Update () {
		
        if (currHealth<=0)
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            AddScore();
            NetworkServer.Destroy(gameObject);
        }
	}


    public void AddScore()
    {
        if(tag == "Enemy")
        {
            player.addScore(100);
              
        }

        if(tag == "Boss")
        {
            player.addScore(1000);
        }
    }
    

    public void Damage(int damage)
    {
        currHealth -= damage;
    }

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().takeDamage(damage);
            anim.SetBool("PlayerFound", true);

        }
       

    }

}
