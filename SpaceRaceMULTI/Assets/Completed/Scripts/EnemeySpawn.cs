using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemeySpawn : NetworkBehaviour {

    public GameObject enemy;
    public GameObject boss;
    public int numberOfEnemies;

    // Use this for initialization

    void spawnEnemy()
    {
        GameObject spawned = (GameObject)Instantiate(enemy, transform.position, transform.rotation);
        spawned.transform.position = this.transform.position;
        NetworkServer.Spawn(spawned);

    }

    private void OnBecameVisible()
    {   
      InvokeRepeating("SpawnLimit",5,5);
    }

    private void OnBecameInvisible()
    {
        CancelInvoke("SpawnLimit");
    }

    private void SpawnLimit()
    {
        if (numberOfEnemies == 0)
        {
            GameObject spawned = (GameObject)Instantiate(boss, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
           

            InvokeRepeating("spawnEnemy", 0, 0);
            numberOfEnemies--;
            Debug.Log(numberOfEnemies);
        }
    }

}
