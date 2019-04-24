using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowParty : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        Populate();
    }

    private void Update()
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
            Text newEntry = Instantiate(text, transform);
            newEntry.GetComponent<Text>().text = a.name + " Power: " + a.power;
        }
    }
}
