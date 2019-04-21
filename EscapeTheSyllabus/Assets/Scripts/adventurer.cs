using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Adventurer", menuName = "Adventurer/Adventurer")]
public class adventurer : ScriptableObject {

	public string adventurerName = "New Adventurer";
	public Sprite icon = null;
	public int health = 0;
    public int power = 0;
    public List<UserData.Skill> skills;

    public void AddToParty()
    {
        if (UserData.instance.party.Count < 4)
        {
            UserData.instance.guild.Remove(this);
            UserData.instance.party.Add(this);
        }
    }

    public void RemoveFromParty()
    {
        UserData.instance.party.Remove(this);
        UserData.instance.guild.Add(this);
    }
}
