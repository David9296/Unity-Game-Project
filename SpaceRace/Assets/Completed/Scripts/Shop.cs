using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public Canvas ShopPanel;

    private void Start()
    {
        ShopPanel = GameObject.Find("ShopCanvas").GetComponent<Canvas>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            OpenShop();
    }

    void OpenShop()
    {
        ShopPanel.enabled = true;
        Time.timeScale = 0;
       // shopMusic.Play();
        //returnMusic.Stop();
    }

    public void CloseShop()
    {
        ShopPanel.enabled = false;

        Time.timeScale = 1;
        //returnMusic.Play();
      //  shopMusic.Stop();
    }


}
