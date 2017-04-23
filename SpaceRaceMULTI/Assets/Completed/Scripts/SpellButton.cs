using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellButton : MonoBehaviour {

    public PlayerShoot playerSpell;
    public int spellNumber;
    private int money;
    public bool sold;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Player playerScript = player.GetComponent<Player>();
        money = playerScript.score;

        GameObject spellShot = GameObject.FindGameObjectWithTag("Player");
        PlayerShoot spell = spellShot.GetComponent<PlayerShoot>();

        if(money >=playerSpell.spells[spellNumber].cost && !sold)
        {
            playerScript.score -= playerSpell.spells[spellNumber].cost;
            playerScript.updateScore();
            spell.currentSpell = spellNumber;
            sold = true;
            StartCoroutine(ToggleSold(5f));

        }

    }

    IEnumerator ToggleSold(float delay)
    {
        yield return new WaitForSeconds(delay);
        sold = false;
    }
}
