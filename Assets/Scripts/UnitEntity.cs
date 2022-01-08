using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitEntity", menuName = "Create UnitEntity")]
public class UnitEntity : ScriptableObject
{
    public new string name;
    public int hp;
    public int at;
    public int cost;
    public Sprite icon;
}
