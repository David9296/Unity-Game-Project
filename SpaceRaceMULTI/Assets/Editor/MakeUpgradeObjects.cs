using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class MakeUpgradeObjects {

   

    [MenuItem("Assets/Create/Spell Object")]


    public static void CreateSpell()
    {
        GunUpgrade asset = ScriptableObject.CreateInstance<GunUpgrade>();
        AssetDatabase.CreateAsset(asset, "Assets/Resources/UpGrades/Guns/newGun.asset");
        AssetDatabase.SaveAssets();
     

    }

    [MenuItem("Assets/Create/Item Object")]

    public static void CreateMelee()
    {
        MeleeUpgrade asset = ScriptableObject.CreateInstance<MeleeUpgrade>();
        AssetDatabase.CreateAsset(asset, "Assets/Resources/UpGrades/Melee/newHitStick.asset");
        AssetDatabase.SaveAssets();
    

    }


}
