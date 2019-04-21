using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class RunQuest : MonoBehaviour
{
    string[] diplomacyEvents = new string[1]
    {
        "The ghost of an ancient king appeared before the party."
    };
    string[] handicraftEvents = new string[1]
    {
        "The party found a broken down wagon, its passengers signaling the party for assistance."
    };
    string[] herbalismEvents = new string[1]
    {
        "In need of more food, the party found mysterious berries."
    };
    string[] magicEvents = new string[1]
    {
        "The party found a strange tome on the ground."
    };
    string[] medicineEvents = new string[1]
    {
        "The party came across an injured horse on the road."
    };
    string[] researchEvents = new string[1]
    {
        "The party found a strange ledger."
    };
    string[] thieveryEvents = new string[1]
    {
        "The party came across a camp of bandits."
    };
    // Start is called before the first frame update
    public Text questUpdatePrefab;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        System.Random rand = new System.Random();
        for (int i = 0; i < 30; i++)
        {
            QuestEvent(UserData.Skill.Diplomacy);
        }
        
    }

    /**
     * Returns the event index
     * 
     **/
    int QuestEvent(UserData.Skill skill)
    {
        Text log = Instantiate(questUpdatePrefab);
        log.transform.SetParent(this.transform);
        System.Random rand = new System.Random();
        int eventNumber = rand.Next(0, 0); //CHANGE RANDOM VALUE LATER
        switch (skill)
        {
            
            case UserData.Skill.Diplomacy:
                log.text = diplomacyEvents[eventNumber];
                break;
            case UserData.Skill.Handicraft:
                log.text = handicraftEvents[eventNumber];
                break;
            case UserData.Skill.Herbalism:
                log.text = herbalismEvents[eventNumber];
                break;
            case UserData.Skill.Magic:
                log.text = magicEvents[eventNumber];
                break;
            case UserData.Skill.Medicine:
                log.text = medicineEvents[eventNumber];
                break;
            case UserData.Skill.Research:
                log.text = researchEvents[eventNumber];
                break;
            case UserData.Skill.Thievery:
                log.text = thieveryEvents[eventNumber];
                break;
            default:
                break;
        }
        return eventNumber;
    }
}
