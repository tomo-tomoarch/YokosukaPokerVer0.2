using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
        CardFlipper flipper;
        CardModel cardModel;
        GameObject[] tagObjects;
        RankGetButton rankGetButton;

    private void Awake()
        {
            flipper = GetComponent<CardFlipper>();
            cardModel = GetComponent<CardModel > ();
            rankGetButton = GameObject.Find("RankGetButton").GetComponent<RankGetButton>();
    }

    private void Update()
    {
        tagObjects = GameObject.FindGameObjectsWithTag("bar");
    }

    // オブジェクトの範囲内にマウスポインタが入った際に呼び出されます。
    public void OnPointerEnter(PointerEventData eventData)
        {
            if(rankGetButton.ToggleMouseOver())
            {
                 cardModel.ToggleFace(true);
            //カードの表面を表示する
            }
        }

        // オブジェクトの範囲内からマウスポインタが出た際に呼び出されます。
        public void OnPointerExit(PointerEventData eventData)
        {
        if (rankGetButton.ToggleMouseOver())
            {
                 flipper.FlipCard(cardModel.faces[cardModel.cardIndex], cardModel.cardBack, -1);
            //カードを裏返すアニメーション処理の呼出
            }
        }
}
