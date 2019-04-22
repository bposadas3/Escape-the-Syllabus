using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "Monster/Monster")]
public class monster : ScriptableObject
{
    public new string name;
    public int power; //from 1 to 400
}
