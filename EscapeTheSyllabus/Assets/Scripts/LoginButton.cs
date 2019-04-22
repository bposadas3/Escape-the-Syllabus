using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoginButton : MonoBehaviour
{
    public Button loginButton;
    public InputField usernameInput;
    public InputField passwordInput;
    public GameObject loginScreen;
    public Text errorMessage;
    public GameObject homeScreen;

    //Delete Later
    public GameObject adminButton;

    private string username;
    private string password;

    void Start()
    {

        loginButton.onClick.AddListener(Authenticate);
        errorMessage.text = "";
    }

    /** 
     * Checks whether the username/password combination is valid.
     **/
    void Authenticate()
    {        //ADD PROPER AUTHENTICATION PROCEDURE
        username = usernameInput.text;
        password = passwordInput.text;

        if (password.Equals(""))
        {
            errorMessage.text = "Password cannot be left blank!";
        }
        else
        {
            Debug.Log("in authenticate!");
            StartCoroutine(ReadFromDB(1.0f, WrapUp));
        }
    }

    void RetrieveAssignments()
    {
        Debug.Log("Retrieve assignments");
        StartCoroutine(Retrieve(2.0f, Finish));
    }

    IEnumerator Retrieve(float waitTime, Action finish)
    {
        Debug.Log("Retrieve");
        IEnumerator e = FirebaseRealtimeDB.instance.GetAssignments();
        yield return new WaitForSeconds(waitTime);
        finish();
    }

    void Finish()
    {
        Debug.Log("Finish");

        FirebaseRealtimeDB f = FirebaseRealtimeDB.instance;
        Debug.Log(f.assignmentNames);
            foreach (Assignment a in f.assignments)
        {
            Debug.Log(a.assignment_name);
        }

    }

    IEnumerator ReadFromDB(float waitTime, Action wrapUp)
    {
        Debug.Log("In ReadFromDB");
        IEnumerator e = FirebaseRealtimeDB.instance.checkPassword(username, password);
        yield return new WaitForSeconds(waitTime);
        Debug.Log("leave ReadFromDB");
        wrapUp();
    }

    void WrapUp()
    {

        Debug.Log("Check firebase call: " + FirebaseRealtimeDB.instance.responseText);
        FirebaseRealtimeDB f = FirebaseRealtimeDB.instance;
        if (f.authCheck)
        {
            loginScreen.SetActive(false);
            homeScreen.SetActive(true);
            errorMessage.text = "";
        }
        else
        {
            //display error message
            errorMessage.text = "Invalid username/password combination!";
        }

    }

    void Update()
    {
        if (usernameInput.isFocused && Input.GetKey(KeyCode.Tab))
        {
            passwordInput.ActivateInputField();
        }

        if (passwordInput.isFocused && Input.GetKey(KeyCode.Return))
        {
            //RetrieveAssignments();
            Authenticate();
        }
    }
}