using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSync : NetworkBehaviour {

    [SyncVar(hook = "FlipCallBack")]
    public bool syncFacingRight = true;
    private SpriteRenderer sprite;

    // Use this for initialization
  
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    [Command]
    public void CmdFlip(bool facing)
    {
        syncFacingRight = facing;

        if (syncFacingRight)
        {

            sprite.flipX = true;
           
        }

        else
        {
            sprite.flipX = false;
        }

    }

    void FlipCallBack(bool facing)
    {
        syncFacingRight = facing;

        if (syncFacingRight)
        {

            sprite.flipX = true;

        }

        else
        {
            sprite.flipX = false;
        }


    }

}
