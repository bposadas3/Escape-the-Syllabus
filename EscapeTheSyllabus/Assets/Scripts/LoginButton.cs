﻿using System.Collections;
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

	private string username;
	private string password;

	void Start() {
	
		loginButton.onClick.AddListener (Authenticate);
		errorMessage.text = " ";
	}

	/**
	 * Checks whether the username/password combination is valid.
	 **/
    void Authenticate(){		//ADD PROPER AUTHENTICATION PROCEDURE
		username = usernameInput.text;
		password = passwordInput.text;

		if (username.Equals ("username") && password.Equals ("password")) {
			loginScreen.SetActive (false);
			homeScreen.SetActive (true);
		} else if (password.Equals("")) {
			errorMessage.text = "Password cannot be left blank!";
		} else {
			//display error message
			errorMessage.text = "Invalid username/password combination!";
		}
    }

	void Update() {
		if (passwordInput.isFocused && Input.GetKey (KeyCode.Return)) {
			Authenticate ();
		}
	}
}