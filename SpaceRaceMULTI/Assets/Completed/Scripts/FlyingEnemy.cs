using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour {

    private Player theplayer;
    public float moveSpeed;
    public float range;
    public LayerMask playerLayer;
    public bool inRange;
    private Animator anim;
   

	// Use this for initialization
	void Start () {
        theplayer = FindObjectOfType<Player>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        inRange = Physics2D.OverlapCircle(transform.position, range, playerLayer);

        if (inRange)
        {

            transform.position = Vector3.MoveTowards(transform.position, theplayer.transform.position, moveSpeed * Time.deltaTime);
            anim.SetBool("PlayerFound", true);
        }
	}

   
}
