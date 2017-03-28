using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemDatabase : MonoBehaviour {

    private List<ItemDb> database = new List<ItemDb>();
    private JsonData itemData;

    void Start()
    {
        
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDatabase();
        Debug.Log(FetchItemByID(0).Title);
    }

    public ItemDb FetchItemByID(int id)
    {
        for (int i = 0; i < database.Count; i++)
        {
            if (database[i].ID==id)
                return database[i];
        }
        return null;
    }

    void ConstructItemDatabase()
    {
        for(int i=0; i< itemData.Count;i++)
        {
            database.Add(new ItemDb((int)itemData[i]["id"], itemData[i]["title"].ToString(), (int)itemData[i]["value"],itemData[i]["slug"].ToString(),(bool)itemData[i]["stackable"]));
        }
    }

}

public class ItemDb
{
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public bool Stackable { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

    public ItemDb(int id, string title,int value,string slug,bool stackable)
    {
        this.ID = id;
        this.Title = title;
        this.Value = value;
        this.Stackable = stackable;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/InventorySprites/" + slug);
    }

    public ItemDb()
    {
        this.ID = -1;
    }

}

