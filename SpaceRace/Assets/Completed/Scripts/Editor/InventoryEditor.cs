﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Inventory))]
public class InventoryEditor : Editor {

    private SerializedProperty itemImagesProperty;
    private SerializedProperty itemsProperty;

    private const string inventoryPropItemImagesName= "itemImages";
    private const string inventoryPropItemName = "items";

    private bool[] showItemSlots = new bool[Inventory.numItemSlots];

    private void OnEnable()
    {
        itemImagesProperty = serializedObject.FindProperty(inventoryPropItemImagesName);
        itemsProperty = serializedObject.FindProperty(inventoryPropItemName);


    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        for(int i = 0; i < Inventory.numItemSlots; i++)
        {
            itemSlotGui(i);
        }


        serializedObject.ApplyModifiedProperties();
    }

    private void itemSlotGui(int index)
    {
        EditorGUILayout.BeginVertical(GUI.skin.box);
        EditorGUI.indentLevel++;

        showItemSlots[index]= EditorGUILayout.Foldout(showItemSlots[index],"Item slot "+index);

        if (showItemSlots[index])
        {
            EditorGUILayout.PropertyField(itemImagesProperty.GetArrayElementAtIndex(index));
            EditorGUILayout.PropertyField(itemsProperty.GetArrayElementAtIndex(index));

        }

        EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical();
    }

}
