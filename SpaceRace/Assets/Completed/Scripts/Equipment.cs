using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour {

    GameObject inventoryPanel;
    GameObject slotPanel;
    ItemDatabase database;
    public GameObject inventorySlot;
    public  GameObject inventoryItem;

    int slotAmount;
    public List<ItemDb> items = new List<ItemDb>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        database = GetComponent<ItemDatabase>();
        slotAmount = 16;
        inventoryPanel = GameObject.Find("EquipmentPanel");
        slotPanel = inventoryPanel.transform.FindChild("SlotPanel").gameObject;

        for(int i = 0; i < slotAmount; i++)
        {
            items.Add(new ItemDb());
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform);
        }

        AddItem(0);
        AddItem(1);
    }

    public void AddItem(int id)
    {
        ItemDb itemToAdd = database.FetchItemByID(id);

        for(int i=0;i<items.Count; i++)
        {
            if(items[i].ID == -1)
            {
                items[i] = itemToAdd;
                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.transform.SetParent(slots[i].transform);
                itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemObj.transform.position = Vector2.zero;
                itemObj.name = itemToAdd.Title;

                break;
            }
        }
    }
}
