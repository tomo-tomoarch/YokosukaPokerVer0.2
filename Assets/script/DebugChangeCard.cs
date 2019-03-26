using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugChangeCard : MonoBehaviour {

    CardModel cardModel;
    //CardModelクラスを参照しますよ。
    int cardIndex = 0;
    //cardIndexの値を宣言

    public GameObject card;  
    //外部から参照する予定のcardというオブジェクトの宣言（後にドラッグアンドドロップ）。

    private void Awake()
    {
        cardModel = card.GetComponent<CardModel>();
        //cardにアタッチされているCardModelを取得して使用します。
    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(10,10,100,28),"Hit me!"))
            //Hit me!!と書いてあるボタンを作って押されたら下記を実行
        {
            if(cardIndex >= cardModel.faces.Length)
                //もしfaces配列の長さよりもcardIndexの値が大きくなったら下記を実行
            {
                cardIndex = 0;
                cardModel.ToggleFace(false);//裏面をレンダー
            }
            else
            {
                cardModel.cardIndex = cardIndex;//cardIndexの値を代入（最初は０）
                cardModel.ToggleFace(true);//表面をレンダー
            }

            cardIndex++;//cardIndexの値をインクリメント
        }
    }

}
