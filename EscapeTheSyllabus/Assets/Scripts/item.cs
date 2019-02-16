using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class item : ScriptableObject {
	public string itemName = "New Item";
	public Sprite icon = null;
}
