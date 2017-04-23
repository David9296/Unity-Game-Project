using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpGrade : ScriptableObject {

    public string UpgradeName = "Player Upgrade";
    public int cost = 100;
    public bool isEquip = false;
    public int HealthStat = 50;
    public int MagicStat = 100;
    public float Jumping = 10f;
}
