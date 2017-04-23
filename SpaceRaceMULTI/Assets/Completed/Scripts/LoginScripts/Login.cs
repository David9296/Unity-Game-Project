using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {


    // Use this for initialization

    public static string Email = "";
    public static string Password = "";

    private string ConfirmPassword = "";
    private string ConfirmEmail = "";

    private string CreateAccountUrl = "http://79.97.103.158/login.php";
    private string LoginUrl = "http://79.97.103.158/LoggingInT.php";

    private string CEmail = "";
    private string CPassword = "";
  
    public string CurrentMenu = "Login";

    public float X, Y, Width, Height;
    public string LoggedInName;

    void Start () {
		
	}
	
   
    void OnGUI()
    {
        if(CurrentMenu == "Login")
        {
            LoginGUI();
        }else if(CurrentMenu == "CreateAccount")
        {
            CreateAccountGUI();
        }

    }


   public void LoginGUI()
    {
        GUI.Box(new Rect(280, 120, (Screen.width/4)+200, (Screen.height/4)+250), "Login");
        if(GUI.Button(new Rect(370,360,120,25), "Create Account")) // Creates GUI box based on Screen Size 
        {
            CurrentMenu = "CreateAccount"; //Changes Menu
        }

        if(GUI.Button(new Rect(570,360,120,25), "Log In"))
        {
            StartCoroutine(LogInAccount());
        }

        GUI.Label(new Rect(420, 200, 220, 25),"Email");
        Email = GUI.TextField(new Rect(420, 225, 220, 25), Email);
        

        GUI.Label(new Rect(420, 250, 220, 25), "Password");
        Password = GUI.TextField(new Rect(420, 270, 220, 25), Password);

    }
	
  public void CreateAccountGUI()
    {

        GUI.Box(new Rect(280, 120, (Screen.width / 4) + 200, (Screen.height / 4) + 250), "Create Account");

        GUI.Label(new Rect(420, 200, 220, 25), "Email");
        CEmail = GUI.TextField(new Rect(420, 225, 220, 25), CEmail);

        GUI.Label(new Rect(420, 250, 220, 25), "Password");
        CPassword = GUI.TextField(new Rect(420, 270, 220, 25), CPassword);

        GUI.Label(new Rect(420, 300, 220, 25), "Confirm Email");
        ConfirmEmail = GUI.TextField(new Rect(420, 320, 220, 25), ConfirmEmail);

        GUI.Label(new Rect(420, 350, 220, 25), "Confirm Password");
        ConfirmPassword = GUI.TextField(new Rect(420, 370, 220, 25), ConfirmPassword);

        if (GUI.Button(new Rect(370, 420, 120, 25), "Create Account"))
        {
          //  CurrentMenu = "CreateAccount";
            if(ConfirmPassword == CPassword && ConfirmEmail == CEmail)
            {
                StartCoroutine(CreateAccount());
                
            }else
            {
                //StartCoroutine("");
            }
        }

        if (GUI.Button(new Rect(570, 420, 120, 25), "Log in"))
        {
            CurrentMenu = "Login";
        }

       

        //StartCoroutine("CreateAccount");
    }

    IEnumerator CreateAccount()
    {
       
        WWWForm form = new WWWForm();
        form.AddField("Email", CEmail);
        form.AddField("Password", CPassword);
        

        WWW CreateAccountWWW = new WWW(CreateAccountUrl, form);
        yield return CreateAccountWWW;

        if(CreateAccountWWW.error != null)
        {
            Debug.LogError("Cannot Connect");
        }
        else
        {
            string CreateAccountReturn = CreateAccountWWW.text;
            Debug.Log(CreateAccountReturn);

            if (CreateAccountReturn == "Success")
            {
                Debug.Log("Success");
                CurrentMenu = "Login";
            }

        }

    }

    IEnumerator LogInAccount()
    {
        //Debug.Log("Attempting to log in");
        WWWForm Form = new WWWForm();
        Form.AddField("Email", Email);
        Form.AddField("Password", Password);

        WWW LoginAccountWWW = new WWW(LoginUrl, Form);

        yield return LoginAccountWWW;

        if (LoginAccountWWW.error != null)
        {
            Debug.LogError("Cannot Connect to Login");
        }

        else
        {
            string LogText = LoginAccountWWW.text;
           
            Debug.Log(LogText);
            string[] LogTextSplit = LogText.Split(':');

            if (LogTextSplit[0] == "0")
            {
                if (LogTextSplit[1] == "Success")
                {
                    
                    SceneManager.LoadScene("newGame");
                }
            }else
            {
                if (LogTextSplit[1] == "Success")
                {
                    PlayerPrefs.SetString("UserName", Email);
                    Debug.Log(PlayerPrefs.GetString("UserName"));
                    SceneManager.LoadScene("NetworkLobby");
                }
            }

        }

    }

}
