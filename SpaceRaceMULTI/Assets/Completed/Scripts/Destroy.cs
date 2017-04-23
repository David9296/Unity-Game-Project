using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    Renderer[] renderers;
    private bool seen = false;

	// Use this for initialization
	void Start () {
        renderers = GetComponentsInChildren<Renderer>();
    }
	
	// Update is called once per frame
	
    void FixedUpdate()
    {
        DeleteOffScreen();
    }

    void DeleteOffScreen()
    {
        seen = CheckRenders();
        if (!seen)
        {
            Destroy(gameObject);
        }
    }

    bool CheckRenders()
    {
        foreach(Renderer renderer in renderers)
        {
            if (renderer.isVisible)
            {
                return true;
              
            }
        }
        return false;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
