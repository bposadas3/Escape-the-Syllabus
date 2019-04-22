using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangeQuest : UnityEvent<quest> { }

public class UserData : MonoBehaviour
{

	public string userName;
	public List<item> inventory;
	public List<adventurer> party;
	public List<quest> questList;
    public List<item> itemDatabase;
    public List<monster> monsterDatabase;

    public List<adventurer> guild;

    public List<adventurer> adventurerDatabase;

	public static UserData instance = null;
	private quest activeQuest;
    private item activeItem;

    public UnityEvent<quest> changeActiveQuest;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

        //*********************DELETE LATER************************
		for (int i = 0; i < 30; i++) {
			quest newQuest = quest.CreateInstance<quest>();
			newQuest.name = "quest" + i.ToString ();
			newQuest.description = ("description" + i.ToString ());
			questList.Add (newQuest);
		}
        System.Random rand = new System.Random();
        for (int i = 0; i < 30; i++)
        {
            adventurer newAdventurer = adventurer.CreateInstance<adventurer>();
            newAdventurer.name = "Adventurer " + i.ToString();
            newAdventurer.power = rand.Next(0, 60);
            guild.Add(newAdventurer);
        }

        inventory.Add(itemDatabase[0]);


        setActiveQuest(questList[0]);
        setActiveItem(inventory[0]);

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
        if (changeActiveQuest == null)
        {
            changeActiveQuest = new ChangeQuest();
            changeActiveQuest.AddListener(setActiveQuest);
        }
	//REPLACE THIS
    }

	public List<quest> getQuestList() {
		return questList;
	}

	public quest getActiveQuest() {
		return activeQuest;
	}

    public void setActiveQuest(quest q)
    {
        activeQuest = q;
    }

    public item getActiveItem()
    {
        return activeItem;
    }

    public void setActiveItem(item i)
    {
        activeItem = i;
    }

    public enum Skill
    {
        Diplomacy,
        Handicraft,
        Herbalism,
        Magic,
        Medicine,
        Research,
        Thievery,
        Trickery
    }

}
