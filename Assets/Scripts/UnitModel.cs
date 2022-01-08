using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitModel: MonoBehaviour
{
    public new string name;
    public int hp;
    public int at;
    public int cost;
    public Sprite icon;
    public bool isAlive = true;

    public UnitModel(int unitId)
    {
        UnitEntity unitEntity = Resources.Load<UnitEntity>("UnitEntityList/Unit" + unitId);
        name = unitEntity.name;
        hp = unitEntity.hp;
        at = unitEntity.at;
        cost = unitEntity.cost;
        icon = unitEntity.icon;
    }

    void Damage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            hp = 0;
            isAlive = false;
        }
    }


    public void Attack(UnitController unit)
    {
        unit.model.Damage(at);
    }
}
