using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Expedition : MonoBehaviour
{
    public Text gameText;
    public Button continueButton;
    public Button returnButton;
    public GameObject itemPrefab;

    public Scrollbar scrollbar;
    private ScrollRect scrollrect;
    public GameObject rewardsWindow;
    public GameObject rewardsScreen;
    private int successPoints;
    private Text buttonText;
    // Start is called before the first frame update
    void Start()
    {
        successPoints = 0;
        buttonText = continueButton.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ContinueQuest()
    {
        buttonText.text = "Continue";
        Text encounter = Instantiate(gameText);
        encounter.transform.SetParent(this.transform);
        monster theMonster = GetRandomMonster();
        if (UserData.instance.party.Count > 0)
        {
            encounter.text = "The party encounters a " + theMonster.name + "!";
        } else
        {
            encounter.text = "You must have at least one member in your party.";
            buttonText.text = "embark";
            scrollbar.value = 0;
            return;
        }
        Text resolution = Instantiate(gameText);
        resolution.transform.SetParent(this.transform);
        if (Battle(theMonster))
        {
            if (successPoints < 2)
            {
                successPoints++;
            } else if (successPoints >= 2 && successPoints < 10)
            {
                successPoints += 2;
            } else
            {
                successPoints += 3;
            }
            resolution.text = "Your party defeated the " + theMonster.name + ". Your party has collected " + successPoints + " treasures so far.";
        } else
        {
            foreach (adventurer a in Lose()) {
                Text deadMemo = Instantiate(gameText);
                deadMemo.transform.SetParent(this.transform);
                deadMemo.text = a.name + " was slain by the " + theMonster.name + ".";
            }
            if (UserData.instance.party.Count <= 0)
            {
                Text loseMemo = Instantiate(gameText);
                loseMemo.transform.SetParent(this.transform);
                loseMemo.text = "Your party was defeated. Their treasures are lost.";
                successPoints = 0;
                continueButton.interactable = false;
            }
        }
        scrollbar.value = 0;

    }

    monster GetRandomMonster()
    {
        System.Random rand = new System.Random();
        int monsterIndex = rand.Next(0, UserData.instance.monsterDatabase.Count);
        return UserData.instance.monsterDatabase[monsterIndex];
    }

    bool Battle(monster m)
    {
        int partyPower = 0;
        foreach (adventurer a in UserData.instance.party)
        {
            partyPower += a.power;
        }

        double chance = (double)partyPower / (double)m.power;
        System.Random rand = new System.Random();
        double theValue = rand.NextDouble();
        return chance > theValue;
    }

    List<adventurer> Lose()
    {
        List<adventurer> deadList = new List<adventurer>();
        System.Random rand = new System.Random();
        int numberDead = rand.Next(1, UserData.instance.party.Count + 1);
        for (int i = 0; i < numberDead; i++)
        {
            int deadOne = rand.Next(0, UserData.instance.party.Count);
            deadList.Add(UserData.instance.party[deadOne]);
            UserData.instance.party.Remove(UserData.instance.party[deadOne]);
        }
        return deadList;
    }

    public void ClearLog()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
        successPoints = 0;
        buttonText.text = "Embark";
        continueButton.interactable = true;
    }

    public void CashIn()
    {
        List<item> rewards = new List<item>();
        int totalTreasures = successPoints;
        System.Random rand = new System.Random();
        for (int i = 0; i < totalTreasures; i++)
        {
            int itemIndex = rand.Next(0, UserData.instance.itemDatabase.Count);
            rewards.Add(UserData.instance.itemDatabase[itemIndex]);
        }
        for (int i = 0; i < rewardsScreen.transform.childCount; i++)
        {
            Destroy(rewardsScreen.transform.GetChild(i).gameObject);
        }
        foreach (item j in rewards)
        {
            GameObject inst = Instantiate(itemPrefab);
            inst.GetComponent<Image>().sprite = j.icon;
            inst.transform.SetParent(rewardsScreen.transform);

            if (!UserData.instance.inventory.Contains(j))
            {
                UserData.instance.inventory.Add(j);
            }
        }
        rewardsWindow.SetActive(true);
        ClearLog();
    }
}
