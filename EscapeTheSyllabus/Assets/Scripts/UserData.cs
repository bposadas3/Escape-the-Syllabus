using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{

	public string userName;
	public List<item> inventory;
	public List<adventurer> party;
	public List<quest> questList;

	public static UserData instance = null;
	private quest activeQuest;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		for (int i = 0; i < 30; i++) {
			quest newQuest = quest.CreateInstance<quest>();
			newQuest.setName("quest" + i.ToString ());
			newQuest.setDescription ("description" + i.ToString ());
			questList.Add (newQuest);
		}

		if (questList.Count != 0) {
			activeQuest = questList [0];
		} else {
			activeQuest = null;
		}
	}

    // Start is called before the first frame update
    void Start()
    {
     //QUERY THE DATABASE FOR INVENTORY ITEMS AND PARTY MEMBERS   

	//REPLACE THIS
    }

	public List<quest> getQuestList() {
		return questList;
	}

	public quest getActiveQuest() {
		return activeQuest;
	}

}
