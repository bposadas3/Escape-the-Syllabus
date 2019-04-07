using System;
using System.Collections;
using System.Collections.Generic;
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

	void Start() {
	
		loginButton.onClick.AddListener (Authenticate);
		errorMessage.text = "";
	}

    void FunctionThatCallsCoroutine()
    {
        StartCoroutine(ExampleFunction());
    }

    IEnumerator ExampleFunction()
    {



        yield return new WaitForSeconds(10f);



    }

    /**
	 * Checks whether the username/password combination is valid.
	 **/
    void Authenticate(){		//ADD PROPER AUTHENTICATION PROCEDURE
		username = usernameInput.text;
		password = passwordInput.text;

        if (password.Equals(""))
        {
            errorMessage.text = "Password cannot be left blank!";
        } else
        {
            Debug.Log("in authenticate!");
            StartCoroutine(ReadFromDB(1.0f, WrapUp));
        }




  //      IEnumerator e = FirebaseRealtimeDB.instance.checkPassword();


  //      //while (e.MoveNext());
  //      StartCoroutine(ExampleFunction());
  //      Debug.Log("Check firebase call: " + FirebaseRealtimeDB.instance.responseText);



		//if (username.Equals ("username") && password.Equals ("password") || username.Equals("admin") && password.Equals("admin")) {
		//	if (username.Equals ("admin") && password.Equals ("admin")) {
		//		adminButton.SetActive (true);
		//	} else {
		//		adminButton.SetActive (false);
		//	}
		//	loginScreen.SetActive (false);
		//	homeScreen.SetActive (true);
  //          errorMessage.text = "";
		//} else if (password.Equals ("")) {
		//	errorMessage.text = "Password cannot be left blank!";
		//} else {
		//	//display error message
		//	errorMessage.text = "Invalid username/password combination!";
		//}
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
        if (f.authCheck) {
          if (f.teacherCheck) {
              adminButton.SetActive (true);
          } else {
              adminButton.SetActive (false);
          }
          loginScreen.SetActive (false);
          homeScreen.SetActive (true);
                  errorMessage.text = "";
        } else {
          //display error message
          errorMessage.text = "Invalid username/password combination!";
        }
    }


    void Update() {
        if (usernameInput.isFocused && Input.GetKey(KeyCode.Tab))
        {
            passwordInput.ActivateInputField();
        }

		if (passwordInput.isFocused && Input.GetKey (KeyCode.Return)) {
			Authenticate ();
		}
	}




}
