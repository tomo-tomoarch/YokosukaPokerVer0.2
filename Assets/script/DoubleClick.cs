using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoubleClick : MonoBehaviour, IPointerClickHandler
{
    CardModel cardmodel;
    public int clickNum = 0; //外部参照用のクリック数の宣言

    void Awake()
    {
        cardmodel = GetComponent<CardModel>();
    }

   public void OnPointerClick(PointerEventData eventData)
   {
       if (eventData.clickCount > 1)
       {
           Debug.Log(eventData.clickCount);
            clickNum = eventData.clickCount;
            cardmodel.ToggleFace(true);
            //下記のこの文を追加しました
            GetComponent<MouseOver>().enabled = false;
            //外部参照用のクリック数（PlayerNetwrokMoverで取得する）
        }
    }
}