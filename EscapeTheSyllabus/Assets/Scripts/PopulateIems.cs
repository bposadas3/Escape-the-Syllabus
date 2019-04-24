using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateIems : MonoBehaviour
{
    public Button button;
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
        foreach (item i in UserData.instance.inventory)
        {
            Button newEntry = Instantiate(button, transform);
            newEntry.GetComponent<Image>().sprite = i.icon;
            newEntry.onClick.AddListener(i.SetAsActiveItem);
            newEntry.onClick.AddListener(Populate);
        }
    }
}
