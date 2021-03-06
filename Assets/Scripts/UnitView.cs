using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitView : MonoBehaviour
{
    //[SerializeField] Text nameText;
    [SerializeField] Text hpText;
    //[SerializeField] Text atText;
    //[SerializeField] Text costText;
    [SerializeField] Image iconImage;

    public void Show(UnitModel cardModel)
    {
        //nameText.text = cardModel.name;
        hpText.text = cardModel.hp.ToString();
        //atText.text = cardModel.at.ToString();
        //costText.text = cardModel.cost.ToString();
        iconImage.sprite = cardModel.icon;
    }

    public void Refresh(UnitModel cardModel)
    {
        hpText.text = cardModel.hp.ToString();
        //atText.text = cardModel.at.ToString();
    }
}
