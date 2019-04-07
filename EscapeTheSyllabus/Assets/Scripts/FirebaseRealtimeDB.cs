using System; using UnityEngine; using UnityEngine.Networking; using System.Collections; using System.Collections.Generic;  
public class FirebaseRealtimeDB : MonoBehaviour
{     public static FirebaseRealtimeDB instance;     public bool authCheck = false;     public String responseText;     public bool teacherCheck = false;      private void Start()     {         if (instance == null)
        {             instance = this;         }
        else if (instance != this)
        {             Destroy(gameObject);         }  
        //Debug.Log("Hello World!");
        //StartCoroutine(GetRequest("https://escape-the-syllabus-5b056.firebaseio.com/Test.json"));      }       public FirebaseRealtimeDB()
    {      }        public IEnumerator checkPassword(String username, String password)
    {
        //Debug.Log("Check Password()");
        IEnumerator e;
        StartCoroutine(e = GetRequest("https://escape-the-syllabus-5b056.firebaseio.com/Users/" + username + ".json", password));         return e;
    }  

    IEnumerator GetRequest(string uri, String password)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;
             authCheck = false;             teacherCheck = false; 
            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                Debug.Log("bool check: " + webRequest.downloadHandler.text != null);                 Debug.Log(webRequest.downloadHandler.text);                 Debug.Log("is null or empty: " + webRequest.downloadHandler.text.Equals("null"));                 if (!webRequest.downloadHandler.text.Equals("null"))
                {                      Student student = JsonUtility.FromJson<Student>(webRequest.downloadHandler.text);                     Debug.Log("Zach testing: " + student.password);                     responseText = webRequest.downloadHandler.text;
                    Debug.Log("ResponseText: " + responseText);
                    responseText = student.password;
                    Debug.Log("PasswordHash: " + responseText);                      authCheck = student.password.Equals(password);                     teacherCheck = student.isTeacher;
                } else
                {
                    Debug.Log("The username is not recognized: " + uri); 
                }
            }
        }
    }
}   