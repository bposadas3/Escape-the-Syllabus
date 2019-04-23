using System; using UnityEngine; using UnityEngine.Networking; using System.Collections;  
public class FirebaseRealtimeDB : MonoBehaviour
{     public static FirebaseRealtimeDB instance;     public ArrayList assignments = new ArrayList();     public String assignmentNames;     public bool authCheck = false;     public String responseText;       private void Start()     {          if (instance == null)
        {             instance = this;         }
        else if (instance != this)
        {             Destroy(gameObject);         }          //Debug.Log(instance);         GetAssignments();     }      public FirebaseRealtimeDB()
    {      }      public IEnumerator registerUser(User user)
    {         IEnumerator e;         String json = JsonUtility.ToJson(user);         Debug.Log("Student as JSON: " + json);
        StartCoroutine(e = RegistrationRequest("https://escape-the-syllabus-5b056.firebaseio.com/Students/" + user.userId + ".json", json));         return e;
    }      public IEnumerator GetAssignments()
    {         StartCoroutine(austinGetAssinments());         //Debug.Log("Hello world");         //Debug.Log("GetAssignments()");         //StartCoroutine(getAssignmentNames());         //foreach (string assignmentName in assignmentNames.Split(','))
        //{             //Debug.Log("AssignmentName: " + assignmentName);
            //StartCoroutine(getAssignmentByName(assignmentName));
        //}         //yield return new WaitForSeconds(1.0f);         //Debug.Log("After waiting: " + assignmentNames);            return null;     }      public IEnumerator austinGetAssinments()
    {

        string uri = "https://escape-the-syllabus-5b056.firebaseio.com/Assignments" + ".json";



        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))         {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();              string[] pages = uri.Split('/');             int page = pages.Length - 1;               if (webRequest.isNetworkError)             {                 Debug.Log(pages[page] + ": Error: " + webRequest.error);             }             else             {                 if (!webRequest.downloadHandler.text.Equals("null"))                 {
                    String rawJSON = webRequest.downloadHandler.text;
                    Assignment assignment1 = JsonUtility.FromJson<Assignment>(rawJSON);

                    String stripedString = rawJSON.Substring(15, rawJSON.Length - 1 -14);
                    bool going = true;
                    while (going)
                    {
                        String assignmentJSON = stripedString.Substring(0, stripedString.IndexOf("}") + 1);
                        stripedString = stripedString.Substring(stripedString.IndexOf("}") + 1);


                        Assignment assignment = JsonUtility.FromJson<Assignment>(assignmentJSON);
                        assignments.Add(assignment);

                        Debug.Log(assignment.assignment_name);


                        if (stripedString.Contains("{")) { 
                            stripedString = stripedString.Substring(stripedString.IndexOf("{"));
                        } else
                        {
                            going = false;
                        }

                        

                    }
                }                 else                 {                     Debug.Log("The username is not recognized: " + uri);                  }             }         }
        
    }      public IEnumerator getAssignmentByName(string name)
    {         Debug.Log("Name: " + name);
        string uri = "https://escape-the-syllabus-5b056.firebaseio.com/Assignments/" + name + ".json";         using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))         {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();              string[] pages = uri.Split('/');             int page = pages.Length - 1;               if (webRequest.isNetworkError)             {                 Debug.Log(pages[page] + ": Error: " + webRequest.error);             }             else             {                 if (!webRequest.downloadHandler.text.Equals("null"))                 {
                    Debug.Log("GetAssignmentByName: " + webRequest.downloadHandler.text);
                    Assignment assignment = JsonUtility.FromJson<Assignment>(webRequest.downloadHandler.text);                     assignments.Add(assignment);
                }                 else                 {                     Debug.Log("The username is not recognized: " + uri);                  }             }         }
    }      public IEnumerator getAssignmentNames()
    {         Debug.Log("getAssignmentNames()");         string uri = "https://escape-the-syllabus-5b056.firebaseio.com/AssignmentNames.json";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))         {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();              string[] pages = uri.Split('/');             int page = pages.Length - 1;               if (webRequest.isNetworkError)             {                 Debug.Log(pages[page] + ": Error: " + webRequest.error);             }             else             {                 Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);                 Debug.Log("bool check: " + webRequest.downloadHandler.text != null);                 Debug.Log(webRequest.downloadHandler.text);                 Debug.Log("is null or empty: " + webRequest.downloadHandler.text.Equals("null"));                 if (!webRequest.downloadHandler.text.Equals("null"))                 {                      //User user = JsonUtility.FromJson<User>(webRequest.downloadHandler.text);                     //Debug.Log("Zach testing: " + user.password);                     assignmentNames = webRequest.downloadHandler.text.Substring(1, webRequest.downloadHandler.text.Length - 2);                     Debug.Log("handler text: " + webRequest.downloadHandler.text);                     Debug.Log("assignmentNames: " + assignmentNames);                     //Debug.Log("ResponseText: " + responseText);                     //responseText = user.password;                     //Debug.Log("PasswordHash: " + responseText);                      //authCheck = user.password.Equals(password);                 }
                else                 {                     Debug.Log("The username is not recognized: " + uri);                  }             }         }
    }      public IEnumerator checkPassword(String username, String password)
    {
        Debug.Log("Check Password()");
        IEnumerator e;
        StartCoroutine(e = LoginRequest("https://escape-the-syllabus-5b056.firebaseio.com/Students/" + username + ".json", password));         return e;
    }      IEnumerator RegistrationRequest(string uri, string data)     {         using (UnityWebRequest webRequest = UnityWebRequest.Put(uri, data))         {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();              string[] pages = uri.Split('/');             int page = pages.Length - 1;              authCheck = false;              if (webRequest.isNetworkError)             {                 Debug.Log(pages[page] + ": Error: " + webRequest.error);             }             else             {                 //Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);                 //Debug.Log("bool check: " + webRequest.downloadHandler.text != null);                 //Debug.Log(webRequest.downloadHandler.text);                 //Debug.Log("is null or empty: " + webRequest.downloadHandler.text.Equals("null"));                 if (!webRequest.downloadHandler.text.Equals("null"))                 {                      User user = JsonUtility.FromJson<User>(webRequest.downloadHandler.text);                     //Debug.Log("Zach testing: " + user.password);                     responseText = webRequest.downloadHandler.text;                     //Debug.Log("ResponseText: " + responseText);                     responseText = user.password;                     //Debug.Log("PasswordHash: " + responseText);                      authCheck = user.password.Equals(user);                 }
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
                //Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                //Debug.Log("bool check: " + webRequest.downloadHandler.text != null);                 //Debug.Log(webRequest.downloadHandler.text);                 //Debug.Log("is null or empty: " + webRequest.downloadHandler.text.Equals("null"));                 if (!webRequest.downloadHandler.text.Equals("null"))
                {                      User user = JsonUtility.FromJson<User>(webRequest.downloadHandler.text);                     //Debug.Log("Zach testing: " + user.password);                     responseText = webRequest.downloadHandler.text;
                    //Debug.Log("ResponseText: " + responseText);
                    responseText = user.password;
                    //Debug.Log("PasswordHash: " + responseText);                      authCheck = user.password.Equals(password);                 } else
                {
                    Debug.Log("The username is not recognized: " + uri); 
                }
            }
        }
    }  
}   