using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeroEntity", menuName = "Create HeroEntity")]
public class HeroEntity : ScriptableObject
{
    public new string name;
    public int hp;
    public int heroPowerChargeTime;
}
