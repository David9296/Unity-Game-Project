using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class MakeUpgradeObjects {

    [MenuItem("Assets/Create/Upgrade Object")]
    public static void Create()
    {
        PlayerUpGrade asset = ScriptableObject.CreateInstance<PlayerUpGrade>();
        AssetDatabase.CreateAsset(asset, "Assets/Resources/UpGrades/newUpgrade.asset");
        AssetDatabase.SaveAssets();
       
    }

    [MenuItem("Assets/Create/Gun Object")]


    public static void CreateGun()
    {
        GunUpgrade asset = ScriptableObject.CreateInstance<GunUpgrade>();
        AssetDatabase.CreateAsset(asset, "Assets/Resources/UpGrades/Guns/newGun.asset");
        AssetDatabase.SaveAssets();
     

    }

    [MenuItem("Assets/Create/Melee Object")]

    public static void CreateMelee()
    {
        MeleeUpgrade asset = ScriptableObject.CreateInstance<MeleeUpgrade>();
        AssetDatabase.CreateAsset(asset, "Assets/Resources/UpGrades/Melee/newHitStick.asset");
        AssetDatabase.SaveAssets();
    

    }


}
