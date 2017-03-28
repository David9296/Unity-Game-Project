using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUpgrade : ScriptableObject {

    public string gunName = "MeleeWeapon";
    public int cost = 100;
    public GameObject prefab;

    public int damage = 10;
    public float SwingSpeed = 10;
    public int durability = 100;


}
