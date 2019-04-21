using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "Monster/Monster")]
public class monster : ScriptableObject
{
    public new string name;
    public new Sprite sprite;
    public string power; //from 1 to 400
}
