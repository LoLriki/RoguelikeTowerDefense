using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    UnitView view; //見かけ(View)に関することを操作
    public UnitModel model; //データ(Model)に関することを操作
    public UnitMovement movement; //移動(Movement)に関することを操作
    public bool isPlayerUnit = false;

    private void Awake()
    {
        view = GetComponent<UnitView>();
        movement = GetComponent<UnitMovement>();
        // isTowerで分岐するべき
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
