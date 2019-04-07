using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SyllabusButton : MonoBehaviour
{
    public Button syllabusButton;

    // Start is called before the first frame update
    void Start()
    {
        syllabusButton.onClick.AddListener(sendToSyllabus);
    }

    // Update is called once per frame
    void sendToSyllabus()
    {
        Application.OpenURL("https://docs.google.com/document/d/1WzNMTld1zEPTwLPdehIyGO6jZxj9PlHirNeV8V2hAD0/edit?usp=sharing");
    }
}
