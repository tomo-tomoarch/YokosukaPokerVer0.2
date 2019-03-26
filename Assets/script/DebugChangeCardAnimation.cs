using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugChangeCardAnimation : MonoBehaviour
{

    CardFlipper flipper;
    CardModel cardModel;   
    int cardIndex = 0;　　

    public GameObject card; 

    void Awake()
    {
        cardModel = card.GetComponent<CardModel>();  
        flipper = card.GetComponent<CardFlipper>();
    }
    void OnGUI()
    {
        if(GUI.Button(new Rect(10,10,100,28), "Hit me!"))　　//もしhitme!ボタンが押された場合下記を実行
         {
             if (cardIndex >= cardModel.faces.Length)   
                // もし　cardIndex が cardModelのfacesのリストの長さ（５２）と同じか大きかったら下記を実行（最後のカードの時の処理）
             {
                 cardIndex = 0;　　　　　　// cardIndex に０を代入
                 flipper.FlipCard(cardModel.faces[cardModel.faces.Length - 1], cardModel.cardBack, -1);　
                // flipCardの実行、引数にデッキの最後のカード,現在のカード,インデックスは-1(CardFlipperで裏面レンダーされる）
             }
             else //それ以外の時
             {
                if (cardIndex > 0)
                 {
                     flipper.FlipCard(cardModel.faces[cardIndex - 1], cardModel.faces[cardIndex], cardIndex);
                    // flipCardの実行、引数に一つ前のカード,現在のカード,インデックス
                }
                else　//cardindexが０の時
                 {
                     flipper.FlipCard(cardModel.cardBack, cardModel.faces[cardIndex], cardIndex);
                    //flipCardの実行、引数に裏面,現在のカード,インデックス
                 }
                 cardIndex++;    //cardIndexをインクリメント
             }

         }

    }
}
