using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlace : MonoBehaviour, IDropHandler
{
    public bool summonedUnit = false;

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        UnitController unit = eventData.pointerDrag.GetComponent<UnitController>();
        if (unit.movement != null)
        {
            Debug.Log(eventData.position);
            Debug.Log("OnDrop");

            unit.movement.defaultParent = this.transform;
            Debug.Log(unit.movement.defaultParent);
            unit.movement.setUnitRoad = true;
            unit.isPlayerUnit = true;
            unit.GetComponent<Collider2D>().enabled = true;
            GameManager.FindObjectOfType<GameManager>().DealCard();
            summonedUnit = true;
        }
    }

}
