using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionButton : MonoBehaviour
{

    public PlayerItems playerItem;
    public int itemNumber;
    private int money;
    public bool sold;

    // Use this for initialization
    void Start()
    {
        sold = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Player playerScript = player.GetComponent<Player>();
        money = playerScript.score;

        GameObject itemUse = GameObject.FindGameObjectWithTag("Player");
        PlayerItems item = itemUse.GetComponent<PlayerItems>();

        if (money >= playerItem.items[itemNumber].cost && !sold)
        {
            playerScript.score -= playerItem.items[itemNumber].cost;
            playerScript.updateScore();
            item.currentItem = itemNumber;
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
