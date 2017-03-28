using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviour {


    // Use this for initialization

    public static string Email = "";
    public static string Password = "";

    private string ConfirmPassword = "";
    private string ConfirmEmail = "";

    private string CreateEmail = "";
    private string CreatePassword = "";

    private string CreateAccountUrl = "";
    private string LoginUrl = "";
    public Canvas loginPanel;
    public Canvas CreatePanel;
    

    void Start () {
		
	}
	
   

   public void LoginGUI()
    {
        loginPanel.enabled = true;
        CreatePanel.enabled = false;
    }
	
  public void CreateAccountGUI()
    {
        CreatePanel.enabled = true;
        loginPanel.enabled = false;
        StartCoroutine("CreateAccount");
    }

    IEnumerator CreateAccount()
    {
        WWWForm form = new WWWForm();
        form.AddField("Email", CreateEmail);
        form.AddField("", CreatePassword);

        WWW CreateAccountWWW = new WWW(CreateAccountUrl, form);
        yield return CreateAccountWWW;

        if(CreateAccountWWW.error != null)
        {
            Debug.LogError("Cannot Connect");
        }
        else
        {
            string CreateAccountReturn = CreateAccountWWW.text;
            if(CreateAccountReturn == "Success")
            {
                Debug.Log("Success");
                //Switch to login
            }

        }

    }

}
