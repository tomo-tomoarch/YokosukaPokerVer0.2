using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomRankGetter : MonoBehaviour {

    public BottomRankSender bottomRankSender;
    public int bottomRank;
    float timer = 1.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CardPrefab"))
        {
            //other.gameObject.SetActive(false); //ぶつかった相手をディアクティベート（消える
            //other.isTrigger = false;

            CardModel cardModel = other.GetComponent<CardModel>(); //ぶつかった相手のCardModel.csにアクセス
            cardModel.ToggleFace(false);
            bottomRank = cardModel.cardIndex;  //ぶつかった相手のカードインデックスをmiddleRankに代入する
            Debug.Log("IndexValue = " + bottomRank); //debuglogに表示させる

            bottomRankSender.Rank(bottomRank);
            Destroy(gameObject, timer);
        }
    }
}
