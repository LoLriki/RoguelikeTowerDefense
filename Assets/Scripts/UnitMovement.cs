using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform defaultParent;
    public bool setUnitRoad = false;
    Vector3 MOVEX = new Vector3(20.0f, 0.0f, 0.0f);

    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultParent = transform.parent;
        transform.SetParent(defaultParent.parent, false); //Ç´ÇÍÇ¢Ç…ìÆÇ©Ç∑ÇΩÇﬂÇ…êeÇÃêeÇé©ï™ÇÃêeÇ…Ç∑ÇÈ
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(defaultParent, false);
        Debug.Log(transform);
        Debug.Log("OnEndDrag");
        transform.localPosition = new Vector3(-320, 0, 0);
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }

    public void SetCardTransfom(Transform parentTransform)
    {
        defaultParent = parentTransform;
        transform.SetParent(defaultParent);

    }

    private Rigidbody2D rb;
    private UnitController opponent;

    public void FixedUpdate()
    {
        if (setUnitRoad)
        {
            transform.Translate(MOVEX * Time.deltaTime);
        }

        if (opponent)
        {
            UnitController unit = GetComponent<UnitController>();
            if (unit.isPlayerUnit != opponent.isPlayerUnit)
            {
                UnitsCombat(unit, opponent);
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        opponent = collision.gameObject.GetComponent<UnitController>();

    }

    void UnitsCombat(UnitController attacker, UnitController defender)
    {
        attacker.model.Attack(defender);
        defender.CheckAlive();
    }

}
