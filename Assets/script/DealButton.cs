using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealButton : MonoBehaviour
{

    Deck deck;
    BottomRankSender bottomRankSender;
    RankGetButton rankGetButton;

    [SerializeField]
    Transform[] spawnPoints;

    public float cardOffset; //カードのずらし幅offsetの宣言
    public Vector3 startfirst;
    public Vector3 startsecond;
    GameObject[] tagObjects;

    private void Awake()
    {
        deck = GetComponent<Deck>();
        rankGetButton = GameObject.Find("RankGetButton").GetComponent<RankGetButton>();
        bottomRankSender = GameObject.Find("BotoomRankSend").GetComponent<BottomRankSender>();
    }

    private void Update()
    {
        tagObjects = GameObject.FindGameObjectsWithTag("CardPrefab");
    }


    void OnGUI()
    {
        if (tagObjects.Length != 26)
        {
            if (GUI.Button(new Rect(450, 130, 100, 28), "Deal"))
            {
                if (PhotonNetwork.player.ID == 1)
                {
                    for (int i = 0; i < 13; i++)
                    {
                        float co = cardOffset * i; //オフセット幅の計算
                        Vector3 temp = startfirst + new Vector3(-co, 0f);//tempというオフセットした位置の計算
                        GameObject cardCopy = (GameObject)PhotonNetwork.Instantiate("card", temp, Quaternion.identity, 0);
                        CardModel cardModel = cardCopy.GetComponent<CardModel>();  // Cardmodel を使用、

                        string card = "card" + i;
                        int indexnumber = (int)PhotonNetwork.room.customProperties[card];
                        cardModel.cardIndex = indexnumber; //Cardmodel.csのcardIndex に　要素の値を渡す
                        cardModel.ToggleFace(true);  //　表面レンダーする
                    }
                }
                else
                {

                    for (int i = 13; i < 26; i++)
                    {
                        float co = cardOffset * i; //オフセット幅の計算
                        Vector3 temp = startsecond + new Vector3(-co, 0f);//tempというオフセットした位置の計算
                        GameObject cardCopy = (GameObject)PhotonNetwork.Instantiate("card", temp, Quaternion.identity, 0);
                        CardModel cardModel = cardCopy.GetComponent<CardModel>();  // Cardmodel を使用、

                        string card = "card" + i;
                        int indexnumber = (int)PhotonNetwork.room.customProperties[card];
                        cardModel.cardIndex = indexnumber; //Cardmodel.csのcardIndex に　要素の値を渡す
                        cardModel.ToggleFace(true);  //　表面レンダーする
                    }
                }
            }
        }
       
    }
}
