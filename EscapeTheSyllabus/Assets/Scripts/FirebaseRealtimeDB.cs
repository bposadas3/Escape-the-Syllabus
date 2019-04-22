using System; using UnityEngine; using UnityEngine.Networking; using System.Collections;  
public class FirebaseRealtimeDB : MonoBehaviour
{     public static FirebaseRealtimeDB instance;     public ArrayList assignments = new ArrayList();     public String assignmentNames;     public bool authCheck = false;     public String responseText;       private void Start()     {         if (instance == null)
        {             instance = this;         }
        else if (instance != this)
        {             Destroy(gameObject);         }     }      public FirebaseRealtimeDB()
    {      }      public IEnumerator registerUser(User user)
    {         IEnumerator e;         String json = JsonUtility.ToJson(user);         Debug.Log("Student as JSON: " + json);
        StartCoroutine(e = RegistrationRequest("https://escape-the-syllabus-5b056.firebaseio.com/Students/" + user.userId + ".json", json));         return e;
    }      public IEnumerator GetAssignments()
    {         StartCoroutine(getAssignmentNames());         yield return new WaitForSeconds(1.0f);         Debug.Log("After waiting: " + assignmentNames);     }      public IEnumerator getAssignmentNames()
    {         string uri = "https://escape-the-syllabus-5b056.firebaseio.com/AssignmentNames.json";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))         {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();              string[] pages = uri.Split('/');             int page = pages.Length - 1;              authCheck = false;              if (webRequest.isNetworkError)             {                 Debug.Log(pages[page] + ": Error: " + webRequest.error);             }             else             {                 Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);                 Debug.Log("bool check: " + webRequest.downloadHandler.text != null);                 Debug.Log(webRequest.downloadHandler.text);                 Debug.Log("is null or empty: " + webRequest.downloadHandler.text.Equals("null"));                 if (!webRequest.downloadHandler.text.Equals("null"))                 {                      //User user = JsonUtility.FromJson<User>(webRequest.downloadHandler.text);                     //Debug.Log("Zach testing: " + user.password);                     assignmentNames = webRequest.downloadHandler.text;                     //Debug.Log("ResponseText: " + responseText);                     //responseText = user.password;                     //Debug.Log("PasswordHash: " + responseText);                      //authCheck = user.password.Equals(password);                 }
                else                 {                     Debug.Log("The username is not recognized: " + uri);                  }             }         }
    }      public IEnumerator checkPassword(String username, String password)
    {
        Debug.Log("Check Password()");
        IEnumerator e;
        StartCoroutine(e = LoginRequest("https://escape-the-syllabus-5b056.firebaseio.com/Students/" + username + ".json", password));         return e;
    }      IEnumerator RegistrationRequest(string uri, string data)     {         using (UnityWebRequest webRequest = UnityWebRequest.Put(uri, data))         {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();              string[] pages = uri.Split('/');             int page = pages.Length - 1;              authCheck = false;              if (webRequest.isNetworkError)             {                 Debug.Log(pages[page] + ": Error: " + webRequest.error);             }             else             {                 Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);                 Debug.Log("bool check: " + webRequest.downloadHandler.text != null);                 Debug.Log(webRequest.downloadHandler.text);                 Debug.Log("is null or empty: " + webRequest.downloadHandler.text.Equals("null"));                 if (!webRequest.downloadHandler.text.Equals("null"))                 {                      User user = JsonUtility.FromJson<User>(webRequest.downloadHandler.text);                     Debug.Log("Zach testing: " + user.password);                     responseText = webRequest.downloadHandler.text;                     Debug.Log("ResponseText: " + responseText);                     responseText = user.password;                     Debug.Log("PasswordHash: " + responseText);                      authCheck = user.password.Equals(user);                 }
                else                 {                     Debug.Log("The username is not recognized: " + uri);                  }             }         }     } 

    IEnumerator LoginRequest(string uri, String password)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;
             authCheck = false; 
            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                Debug.Log("bool check: " + webRequest.downloadHandler.text != null);                 Debug.Log(webRequest.downloadHandler.text);                 Debug.Log("is null or empty: " + webRequest.downloadHandler.text.Equals("null"));                 if (!webRequest.downloadHandler.text.Equals("null"))
                {                      User user = JsonUtility.FromJson<User>(webRequest.downloadHandler.text);                     Debug.Log("Zach testing: " + user.password);                     responseText = webRequest.downloadHandler.text;
                    Debug.Log("ResponseText: " + responseText);
                    responseText = user.password;
                    Debug.Log("PasswordHash: " + responseText);                      authCheck = user.password.Equals(password);                 } else
                {
                    Debug.Log("The username is not recognized: " + uri); 
                }
            }
        }
    }  
}   