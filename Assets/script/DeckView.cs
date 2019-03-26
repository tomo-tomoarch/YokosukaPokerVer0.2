using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Deck))] 
public class DeckView : MonoBehaviour {

    Deck deck; //Deckクラスを参照します

    public Vector3 start;  //最初のカードの位置
    public float cardOffset;　//カードをずらす幅
    public GameObject cardPrefab;　//instantiateするプレファブ

    private void Start()
    {
        deck = GetComponent<Deck>();　//Deck.csの取得
        ShowCards();　//下記メソッドの実行
    }

    void ShowCards()　//メソッド本体
    {
        int cardCount = 0;　//内部で使う値cardCountの宣言

        foreach(int i in deck.GetCards())
        {
            float co = cardOffset * cardCount; //オフセット幅の計算

            GameObject cardCopy = (GameObject)Instantiate(cardPrefab);
           　　　　　 //カードプレファブのコピー
            Vector3 temp = start + new Vector3(co, 0f);　
            　　　　　//tempというオフセットした位置の計算
            cardCopy.transform.position = temp;
            //現在の位置にtempを代入

            CardModel cardModel = cardCopy.GetComponent<CardModel>();
            //コピーしたカードプレファブのCardModelクラスを取得
            cardModel.cardIndex = i;
            //インデックスにiを代入
            cardModel.ToggleFace(true);
            //表面をレンダー（カードゲームを作りたい第2回目で作成したスクリプトを使用）

            cardCount++;　//cardCountをインクリメント

        }
    }
}
