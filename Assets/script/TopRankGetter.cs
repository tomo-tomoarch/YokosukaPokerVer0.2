using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopRankGetter : MonoBehaviour {

    public TopRankSender topRankSender;
    public int topRank;
    float timer = 1.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CardPrefab"))
        {
            //other.gameObject.SetActive(false); //ぶつかった相手をディアクティベート（消える
            //other.isTrigger = false;

            CardModel cardModel = other.GetComponent<CardModel>(); //ぶつかった相手のCardModel.csにアクセス
            cardModel.ToggleFace(false);
            topRank = cardModel.cardIndex;  //ぶつかった相手のカードインデックスをmiddleRankに代入する
            Debug.Log("IndexValue = " + topRank); //debuglogに表示させる

            topRankSender.Rank(topRank);
            Destroy(gameObject, timer);
        }
    }
}
