using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryManager : MonoBehaviour
{
	public List<item> inventory;

    void Start()
    {
		inventory = new List<item> (); //replace with retreived inventory
    }
		
    void Update()
    {
        
    }
}
