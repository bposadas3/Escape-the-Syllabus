using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPDF : MonoBehaviour
{
    public Button pdfButton;
    // Start is called before the first frame update
    void Start()
    {
        pdfButton.onClick.AddListener(Open);
    }

    // Update is called once per frame
    void Open()
    {
        Application.OpenURL("https://docs.google.com/document/d/11Gtt2SEGp960EKXt_cWNGwCKAnpEkWkuhReJxcKphoM/edit?usp=sharing");
    }
}
