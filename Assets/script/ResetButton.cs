using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour {

    Deck deck;
    MiddleJudge middleJudge;
    GameControler gameControler;
    BottomGameControler bottomGameControler;
    TopGameControler topGameControler;
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
        middleJudge = GameObject.Find("MiddleJudge").GetComponent<MiddleJudge>();
        gameControler = GameObject.Find("GameControler").GetComponent<GameControler>();
        bottomGameControler = GameObject.Find("BottomGameControler").GetComponent<BottomGameControler>();
        topGameControler = GameObject.Find("TopGameControler").GetComponent<TopGameControler>();
    }

    private void Update()
    {
        tagObjects = GameObject.FindGameObjectsWithTag("CardPrefab");
    }

    void OnGUI()
    {
        if (tagObjects.Length == 26)
        {
            if (GUI.Button(new Rect(450, 130, 100, 28), "Reset"))
            {
                GameObject[] Cards = GameObject.FindGameObjectsWithTag("CardPrefab");
                bottomRankSender.ResetRank();
                rankGetButton.flipflip = false;
                deck.Shuffle();

                middleJudge.topwinner = "";
                middleJudge.winner = "";
                middleJudge.bottomwinner = "";
                gameControler.screen = "";
                bottomGameControler.screen = "";
                topGameControler.hand = "";

                foreach (GameObject i in Cards)
                {
                    Destroy(i);
                }
                
                int cardCount = 0; //内部で使う値cardCountの宣言

                foreach (int i in deck.GetCards())
                {
                    if (cardCount < 26)
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
        }
    }
}
