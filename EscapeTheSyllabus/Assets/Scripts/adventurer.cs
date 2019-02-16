using UnityEngine;

[CreateAssetMenu(fileName = "New Adventurer", menuName = "Adventurer/Adventurer")]
public class adventurer : ScriptableObject {

	public string adventurerName = "New Adventurer";
	public Sprite icon = null;
	public int health;
}
