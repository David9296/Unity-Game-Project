using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenRegion : MonoBehaviour {

    Rigidbody2D rb2d;
    BoxCollider2D colliderBounds;

    void Awake()
    {
        colliderBounds = gameObject.GetComponent<BoxCollider2D>();
        rb2d = gameObject.AddComponent<Rigidbody2D>();
        rb2d.isKinematic = true;
    }

    void SetNewCameraBounds()
    {
        CameraBounds camera = Camera.main.gameObject.GetComponent<CameraBounds>();
        camera.SetNewBounds(colliderBounds.bounds);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            SetNewCameraBounds();
        }
    }
}

