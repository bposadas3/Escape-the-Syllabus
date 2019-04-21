using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class item : ScriptableObject {
	public string itemName = "New Item";
	public Sprite icon = null;
    public string description = "No Description";

    public void SetAsActiveItem()
    {
        UserData.instance.setActiveItem(this);
    }
}
