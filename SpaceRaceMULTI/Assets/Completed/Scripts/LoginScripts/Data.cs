using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour {

    private string saveUrl = "http://79.97.103.158/saveData.php";
    private string loadUrl = "http://79.97.103.158/loadData.php";
    private string Email;
    public static int potion;
    public static int score;
    Login currentUser;
    PlayerItems player;
    Player playerScore;
    public string[] items;
    public int loadScore;
    private int loadItem;

    // Use this for initialization

    
    void Start () {
        player = FindObjectOfType<PlayerItems>();
        Email = PlayerPrefs.GetString("UserName");
        playerScore = FindObjectOfType<Player>();

        StartCoroutine(loadData());
       
      
    }
	
	// Update is called once per frame
	void Update () {
        potion = player.currentItem;
        score = playerScore.score;

        if (Input.GetButtonDown("Save"))
        {
            
           
            StartCoroutine(SaveData(Email, potion, score));
        }

	}

    IEnumerator SaveData(string email,int potion,int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("Email", Email);
        form.AddField("Potion", potion);
        form.AddField("Score", score);

        WWW saveDataWWW = new WWW(saveUrl, form);

        yield return saveDataWWW;

        if (saveDataWWW.error != null)
        {
            Debug.Log("Cannot Connect");
        }

        else
        {
            Debug.Log("Success");
        }

    }

    IEnumerator loadData()
    {
        WWWForm form = new WWWForm();
        form.AddField("Email", Email);


        WWW data = new WWW(loadUrl, form);
        yield return data;

        if (data.error != null)
        {
            Debug.Log("Cannot Connect");
        }

        else
        {

            string dataString = data.text;

            items = dataString.Split(';');// Splits data at SemiColon
            string Stringscore = GetData(items[0], "Score:");
            string itemCurrent = GetData(items[0], "Potion:");

            loadItem = int.Parse(itemCurrent);
            loadScore = int.Parse(Stringscore);

            player.currentItem = loadItem;
            playerScore.addScore(loadScore);
            print(loadScore);
        }
    }

    string GetData(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length); // Takes in substring of user data from database at indexPosition
        if (value.Contains("|"))
        
            value = value.Remove(value.IndexOf("|")); //Splits at
            return value;
        
    }
}
