using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    UnitView view; //������(View)�Ɋւ��邱�Ƃ𑀍�
    public UnitModel model; //�f�[�^(Model)�Ɋւ��邱�Ƃ𑀍�
    public UnitMovement movement; //�ړ�(Movement)�Ɋւ��邱�Ƃ𑀍�
    public bool isPlayerUnit = false;

    private void Awake()
    {
        view = GetComponent<UnitView>();
        movement = GetComponent<UnitMovement>();
        // isTower�ŕ��򂷂�ׂ�
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
