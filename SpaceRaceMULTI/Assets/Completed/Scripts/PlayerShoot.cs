using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    public float shotSpeed;

   
    private float nextFire;

    public GunUpgrade[] spells;
    public int currentSpell;

    public int maxMagic = 100;
    public int currentMagic;
    public float magicRecovery;
    public float position;

    public Player player;
    public bool canFire;
    float lastx;
    Text magic;
    
    void Awake()
    {
        player = transform.GetComponent<Player>();
    }

    // Use this for initialization
    void Start () {
       
        setMaxMagic();
        magic = GameObject.FindGameObjectWithTag("MagicNumber").GetComponent<Text>();
        InvokeRepeating("MagicRestore", 5, 5);
       
    }
	
	// Update is called once per frame
	void Update ()
    {

        
        
        updateMagic();

        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1") && Time.time > nextFire && canFire && currentSpell > 0)
        {
            CmdFire();
        } 
            
       
    }

    [Command]
    void CmdFire()
    {
     
            nextFire = Time.time + spells[currentSpell].fireRate;
            GameObject spell = (GameObject)Instantiate(spells[currentSpell].prefab, shotSpawn.position, shotSpawn.rotation);

            currentMagic = currentMagic - spells[currentSpell].magicCost;

            shotSpeed = spells[currentSpell].shotSpeed;
            if (lastx < 0)
            {

                shotSpeed = -shotSpeed;
                spell.GetComponentInChildren<SpriteRenderer>().flipX = true;

            }


            spell.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(shotSpeed, GetComponent<Rigidbody2D>().velocity.y) * Time.deltaTime;
        
        NetworkServer.Spawn(spell);
    }


    void FixedUpdate()
    {
        checkMagic();

        if (!isLocalPlayer)
        {
            return;
        }

        position = Input.GetAxis("Horizontal");

     

        if (position!= 0)
        {
            lastx = position;
        }

        
    }

    public void setMaxMagic()
    {
        currentMagic = maxMagic;
    }

    public void checkMagic()
    {
        if(spells[currentSpell].magicCost > currentMagic)
        {
            canFire = false;
        }

        if (spells[currentSpell].magicCost < currentMagic)
        {
            canFire = true;
        }
    }

    public void updateMagic()
    {
        magic.text = currentMagic.ToString();
    }

 

    void MagicRestore()
    {
        if(currentMagic < 50)
        {
            currentMagic++;
        }
    }
}
