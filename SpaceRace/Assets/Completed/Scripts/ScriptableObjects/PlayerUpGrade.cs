using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpGrade : ScriptableObject {

    public string UpgradeName = "Player Upgrade";
    public int cost = 100;
    public bool isEquip = false;
    public float speed = 10f;
}
