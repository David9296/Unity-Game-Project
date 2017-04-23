using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public Transform telepoint;

	void Update () {}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag=="Player")
        {
            coll.gameObject.transform.position = telepoint.transform.position;

        }
    }
}
