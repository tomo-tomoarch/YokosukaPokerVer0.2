using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //text 使うので

public class NetworkManager : MonoBehaviour {

    Deck deck; //Deckクラスを参照します
    ChipCalculator chipCalculator;

    [SerializeField] Text connectionText;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] Camera sceneCamera;

    public float cardOffset; //カードのずらし幅offsetの宣言
    public Vector3 startfirst;
    public Vector3 startsecond;
    GameObject player;

    private void Awake()
    {
        chipCalculator = GetComponent<ChipCalculator>();
    }

    void Start()
    {
        PhotonNetwork.logLevel = PhotonLogLevel.Full;
        PhotonNetwork.ConnectUsingSettings("0.1");

        deck = GetComponent<Deck>(); //Deck.csの取得
    }

    void Update()
    {
        connectionText.text = PhotonNetwork.connectionStateDetailed.ToString();

    }

    void OnJoinedLobby()
    {
        RoomOptions ro = new RoomOptions() { isVisible = true, maxPlayers = 2 };
        PhotonNetwork.JoinOrCreateRoom("Tomo", ro, TypedLobby.Default);

    }

    void OnJoinedRoom()
    {
        if (PhotonNetwork.playerList.Length == 1)
        {
            chipCalculator.ChipShow(13000, 1);

            int index = 0;
            int cardCount = 0;　//内部で使う値cardCountの宣言
            deck.Shuffle();

            foreach (int i in deck.GetCards())
            {
                if (cardCount < 13)
                {
                    float co = cardOffset * cardCount; //オフセット幅の計算
                    Vector3 temp = startfirst + new Vector3(-co, 0f);
                    //tempというオフセットした位置の計算
                    GameObject cardCopy = (GameObject)PhotonNetwork.Instantiate("Card", temp, spawnPoints[index].rotation, 0);
                    //カードプレファブのコピー

                    CardModel cardModel = cardCopy.GetComponent<CardModel>();
                    //コピーしたカードプレファブのCardModelクラスを取得
                    cardModel.cardIndex = i;//インデックスにiを代入
                    cardModel.ToggleFace(true);
                    //表面をレンダー（カードゲームを作りたい第2回目で作成したスクリプトを使用）

                    cardCount++; //cardCountをインクリメント
                } else if(cardCount < 26)
                {
                    var properties = new ExitGames.Client.Photon.Hashtable();
                        string card = "card" + cardCount;
                        properties.Add(card, i);
                        PhotonNetwork.room.SetCustomProperties(properties);
                    cardCount++;
                }
                else
                {
                    break;
                }
               
            }
              
        }
        else
        {
            chipCalculator.ChipShow(13000, -1);

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
