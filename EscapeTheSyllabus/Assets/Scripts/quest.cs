using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class quest : ScriptableObject
{
	public new string name = "New Quest";
	public string description = "Description";
    public string link = "https://docs.google.com/document/d/11Gtt2SEGp960EKXt_cWNGwCKAnpEkWkuhReJxcKphoM/edit?usp=sharing";

    public void setAsActiveQuest()
    {
        UserData.instance.setActiveQuest(this);
    }

    public void openQuestLink()
    {
        Application.OpenURL(link);
    }
}
