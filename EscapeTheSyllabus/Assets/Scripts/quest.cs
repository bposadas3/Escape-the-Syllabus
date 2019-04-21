using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class quest : ScriptableObject
{
	public new string name = "New Quest";
	public string description = "Description";
    public string qlink = "";

    public void setAsActiveQuest()
    {
        UserData.instance.setActiveQuest(this);
    }
}
