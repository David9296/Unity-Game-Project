using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{

    public int Shotdamage;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Boss")
        {
            coll.gameObject.GetComponent<Enemy>().Damage(Shotdamage);
        }

    }
}