using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

    public int dmg = 20;
    private AudioSource clp;

    void Awake()
    {
        clp = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.isTrigger!=true && coll.CompareTag("Enemy") || coll.isTrigger != true && coll.CompareTag("Boss")) //Checks for Collions that arent triggers and compares to find enemy or boss objects;
        {
            clp.Play();
            coll.SendMessageUpwards("Damage", dmg);

        }
    }

}
