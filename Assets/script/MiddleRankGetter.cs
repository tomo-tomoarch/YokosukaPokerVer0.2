using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleRankGetter : MonoBehaviour {

    public MiddleRankSender middleRankSender;
    public int middleRank;
    float timer = 1.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CardPrefab"))
        {
            //other.gameObject.SetActive(false); //ぶつかった相手をディアクティベート（消える
            //other.isTrigger = false;
 
            CardModel cardModel = other.GetComponent<CardModel>(); //ぶつかった相手のCardModel.csにアクセス
            cardModel.ToggleFace(false);
            middleRank = cardModel.cardIndex;  //ぶつかった相手のカードインデックスをmiddleRankに代入する
            Debug.Log("IndexValue = " + middleRank); //debuglogに表示させる

            middleRankSender.Rank(middleRank);
            Destroy(gameObject, timer);
        }
    }
}
