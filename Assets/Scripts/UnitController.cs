using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    UnitView view; //Œ©‚©‚¯(View)‚ÉŠÖ‚·‚é‚±‚Æ‚ğ‘€ì
    public UnitModel model; //ƒf[ƒ^(Model)‚ÉŠÖ‚·‚é‚±‚Æ‚ğ‘€ì
    public UnitMovement movement; //ˆÚ“®(Movement)‚ÉŠÖ‚·‚é‚±‚Æ‚ğ‘€ì
    public bool isPlayerUnit = false;

    private void Awake()
    {
        view = GetComponent<UnitView>();
        movement = GetComponent<UnitMovement>();
        // isTower‚Å•ªŠò‚·‚é‚×‚«
        if(GetComponent<UnitController>().tag == "Unit")
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }
    public void Init(int unitId)
    {
        model = new UnitModel(unitId);
        view.Show(model);
    }

    public void CheckAlive()
    {
        if (model.isAlive)
        {
            view.Refresh(model);
        }
        else
        {
            Debug.Log("Destroyed");
            Destroy(this.gameObject);
        }
    }
}
