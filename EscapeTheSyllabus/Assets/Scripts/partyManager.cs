using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
	public List<adventurer> party;
    // Start is called before the first frame update
    void Start()
    {
		party = new List<adventurer> (); //replace with loaded party from database
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
