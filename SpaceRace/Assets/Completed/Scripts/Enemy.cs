using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int maxHealth = 40;
    public int currHealth ;
	// Use this for initialization
	void Start () {

        currHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (currHealth<=0)
        {
            Destroy(gameObject);
        }
	}

    public void Damage(int damage)
    {
        currHealth -= damage;
    }
}
