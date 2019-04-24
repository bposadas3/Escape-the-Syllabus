using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyPopulate : MonoBehaviour
{
    public Button button;
    public GameObject characterWindow;
    // Start is called before the first frame update
    void Start()
    {
        Populate();
    }

    public void Populate()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
        foreach (adventurer a in UserData.instance.party)
        {
            Button newEntry = Instantiate(button, transform);
            newEntry.GetComponentInChildren<Text>().text = a.name + " Power:" + a.power;
            newEntry.onClick.AddListener(a.RemoveFromParty);
            newEntry.onClick.AddListener(Populate);
            newEntry.onClick.AddListener(characterWindow.GetComponent<PartyList>().Populate);
        }
    }
}
