using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUpgrade : ScriptableObject {

    public string gunName = "Gun";
    public int cost = 100;
    public GameObject prefab;

    public int damage = 10;
    public float shotSpeed = 20;
    public float fireRate = 0;
    public int shotCount = 100;

}
