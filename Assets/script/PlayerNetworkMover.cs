using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetworkMover : Photon.MonoBehaviour
{
    CardModel card;
    DoubleClick doubleClick;

    Vector3 position;
    int clickedNum;
    float smoothing = 1f;

    void Awake()
    {
        card = GetComponent<CardModel>();
        doubleClick = GetComponent<DoubleClick>();
    }

    void Start()
    {
        if (photonView.isMine)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            StartCoroutine("UpdateData");
        }
    }
    IEnumerator UpdateData()
    {
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * smoothing);
            yield return null;
        }
    }
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.isWriting)
        {
            stream.SendNext(transform.position);　//現在のポジションを送る
            stream.SendNext(card.cardIndex);　//cardIndexの情報を送る
            stream.SendNext(doubleClick.clickNum);　//クリックされた回数を送る
        }
        else
       {
           CardModel cardModel = GetComponent<CardModel>();　//受信先のCardModelを取得
           position = (Vector3)stream.ReceiveNext();　//現在のポジションを受信
            cardModel.cardIndex = (int)stream.ReceiveNext(); //cardIndexの情報を受信
            clickedNum = (int)stream.ReceiveNext(); //クリックされた回数を受信

            if (clickedNum >= 2) //クリックされた回数が2回だった場合
            {
               cardModel.ToggleFace(true);　//表をレンダー
           }
            else
           {
               cardModel.ToggleFace(false); //裏をレンダー
            }
       }
    }
}