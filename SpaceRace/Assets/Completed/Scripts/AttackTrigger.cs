using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

    public int dmg = 20;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.isTrigger!=true && coll.CompareTag("Enemy"))
        {
            coll.SendMessageUpwards("Damage", dmg);

        }
    }

}
