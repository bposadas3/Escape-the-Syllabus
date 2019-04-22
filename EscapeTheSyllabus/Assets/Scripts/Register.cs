using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    public Button registerButton;
    public Button cancelButton;
    public InputField firstNameInput;
    public InputField lastNameInput;
    public InputField idInput;
    public InputField passwordInput;
    public InputField confirmPasswordInput;
    public Text errorMessage;
    public Text successMessage;

    public GameObject loginScreen;
    public GameObject registerScreen;

    private User user;

    // Start is called before the first frame update
    void Start()
    {
        registerButton.onClick.AddListener(RegisterUser);
        cancelButton.onClick.AddListener(Cancel);
        errorMessage.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            RegisterUser();
        }
    }

    private void RegisterUser()
    {
        if (!firstNameInput.text.Equals("") && !lastNameInput.text.Equals("") && !idInput.text.Equals("")
            && !passwordInput.text.Equals(""))
        {
            if (passwordInput.text.Equals(confirmPasswordInput.text))
            {

                this.user = new User("email", firstNameInput.text, lastNameInput.text, 0, "", "", "", passwordInput.text, idInput.text, 1);

                StartCoroutine(ReadFromDB(1.0f, WrapUp));



                //Register user to database
            }
            else
            {
                errorMessage.text = "Passwords do not match. Please try again.";
            }
        }
        else
        {
            errorMessage.text = "All fields must be filled out.";
        }
    }

    IEnumerator ReadFromDB(float waitTime, Action wrapUp)
    {
        Debug.Log("In ReadFromDB");
        IEnumerator e = FirebaseRealtimeDB.instance.registerUser(this.user);
        yield return new WaitForSeconds(waitTime);
        Debug.Log("leave ReadFromDB");
        wrapUp();
    }

    void WrapUp()
    {
        errorMessage.text = "";
        successMessage.text = "Successfully Registered!";
        ClearInputs();
        registerScreen.SetActive(false);
        loginScreen.SetActive(true);
    }

    private void ClearInputs()
    {
        firstNameInput.text = "";
        lastNameInput.text = "";
        idInput.text = "";
        passwordInput.text = "";
        confirmPasswordInput.text = "";
    }

    private void Cancel()
    {
        ClearInputs();
        errorMessage.text = "";
    }
}
