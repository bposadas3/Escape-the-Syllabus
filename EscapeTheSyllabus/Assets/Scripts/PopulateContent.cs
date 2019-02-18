using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateContent : MonoBehaviour
{
	private int numQuests;
	private List<quest> questList;

	//This Prefab should be a button that changes the values in the quest window, then sets the quest window to active
	public Button buttonPrefab;

    // Start is called before the first frame update
    void Start()
    {

		questList = UserData.instance.getQuestList();
		numQuests = questList.Count;

		print (numQuests);

		Populate ();
    }

	void Populate() {
		Button newButton;
		if (questList.Count != 0) {
			foreach (quest q in questList) {
				newButton = Instantiate (buttonPrefab, transform);
				newButton.name = q.getName ();
			}
		}
	}
}
