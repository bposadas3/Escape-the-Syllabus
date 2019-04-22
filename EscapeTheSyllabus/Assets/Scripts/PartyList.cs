using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class AdventurerComparator : IComparer<adventurer>
{
    public int Compare(adventurer x, adventurer y)
    {
        if (!(x.power == y.power)) {
            return y.power - x.power;
        } else
        {
            return x.name.CompareTo(y.name);
        }
    }
}

public class PartyList : MonoBehaviour
{
    public Button button;
    public GameObject partyList;
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
        AdventurerComparator comp = new AdventurerComparator();
        UserData.instance.guild.Sort(comp);
        foreach (adventurer a in UserData.instance.guild)
        {
            Button newEntry = Instantiate(button);
            newEntry.GetComponentInChildren<Text>().text = a.name + " Power:" + a.power;
            newEntry.transform.SetParent(this.transform);
            newEntry.onClick.AddListener(a.AddToParty);
            newEntry.onClick.AddListener(Populate);
            newEntry.onClick.AddListener(partyList.GetComponent<PartyPopulate>().Populate);
        }
    }
}
