using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItems : MonoBehaviour {

    public MeleeUpgrade[] items;
    public int currentItem;
    public Player player;
    public PlayerShoot pshoot;
    
    Text potion;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<Player>();
        pshoot = FindObjectOfType<PlayerShoot>();
        potion = GameObject.FindGameObjectWithTag("ItemType").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            

            if(currentItem == 0)
            {
                //
            }

            if(currentItem == 1 && player.currentHealth <= 50 )
            {
                
                player.currentHealth += items[currentItem].boostAmount;
                currentItem = 0;
            }

            if (currentItem == 2 && pshoot.currentMagic <=50)
            {
                
                pshoot.currentMagic += items[currentItem].boostAmount;
                currentItem = 0;
            }

           
        }

        updateItems();
     }

    void updateItems()
    {
        potion.text = items[currentItem].potionName;
    }



    
}
