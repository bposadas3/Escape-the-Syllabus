using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PopulateContent : MonoBehaviour
{

	private int numQuests;
	private List<quest> questList;

	//This Prefab should be a button that changes the values in the quest window, then sets the quest window to active
	public Button buttonPrefab;
    public GameObject questWindow;

    // Start is called before the first frame update
    void Start()
    {

		questList = UserData.instance.getQuestList();
		numQuests = questList.Count;

		print (numQuests);

		Populate ();
    }

    private void Update()
    {
        if (questList.Count == 0)
        {
            Populate();
        }
    }

    void Populate() {
		Button newButton;
        UserData.instance.GetAssignments();
        if (questList.Count != 0) {
			foreach (quest q in questList) {
				newButton = Instantiate (buttonPrefab, transform);
				newButton.name = q.name;
                newButton.onClick.AddListener(q.setAsActiveQuest);
                newButton.onClick.AddListener(ActivateQuestWindow);
			}
		}
	}

    void ActivateQuestWindow()
    {
        questWindow.SetActive(true);
    }
}
