using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopGameControler : MonoBehaviour {

    //変数
    RankGetButton rankGetButton;

    private int player;
    private int[] handRank;

    int[] handNumber;

    public string hand;
    int rankPoint;

    GameObject[] tagObjects;
    int buttonX;

    private void Awake()
    {
        rankGetButton = GameObject.Find("RankGetButton").GetComponent<RankGetButton>();
        handRank = new int[3] { 0, 0, 0};
    }

    private void Update()
    {
       // tagObjects = GameObject.FindGameObjectsWithTag("bar");
    }

    void OnJoinedRoom()
    {

        if (PhotonNetwork.player.ID == 1)
        {
            buttonX = 890;
        }
        else
        {
            buttonX = 20;
        }
    }

    void OnGUI()
    {
        if (rankGetButton.ToggleReadyTop())
        {
            if (GUI.Button(new Rect(buttonX, 70, 100, 28), "check hand!!"))
            {

                int rank = (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "topRankhand0"];
                int rankB = (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "topRankhand1"];
                int rankC = (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "topRankhand2"];

                handRank = new int[3] { rank, rankB, rankC}; //リストの作成
                RankJudge();

                rankGetButton.top = false;
            }
        }
    }


    public void RankJudge()
    {
        //役判定メソッド本体がここに入る
        if (handRankCalc() > 2 * 16 * 16 * 16)
        {
            Debug.Log("You got 3 of a kind! " + handRankCalc());
            hand = "You got 3 of a kind!" + handRankCalc();
            sendhandrank(handRankCalc());
        }
        else if (handRankCalc() > 16* 16 * 16)
        {
            Debug.Log("You got one pair" + handRankCalc());
            hand = "You got one pair" + handRankCalc();
            sendhandrank(handRankCalc());
        }
        else if (handRankCalc() > 13)
        {
            string i;
            Debug.Log("you are pig." + handRankCalc());
            i = "you are pig." + handRankCalc().ToString();
            hand = i;
            sendhandrank(handRankCalc());
        }
        else
        {
            Debug.Log("You are mistery, report this bug");
            hand = "You are mistery, report this bug";
        }
    }
    
    public int handRankCalc()
    {
        //得点計算メソッド本体がここに入る
    
        int k;

        handNumber = new int[3] {0, 0, 0};

        for (k = 0; k < 3; k++)
        {
            if (handRank[k] % 13 != 0)
            {
                handNumber[k] = handRank[k] % 13 + 1;
            }
            else
            {
                handNumber[k] = 14;
            }
        }

        var list = new List<int>();
        list.AddRange(handNumber);
        list.Sort();
        list.Reverse();

        int i;
        int j;
        int doubling = 0;
        for (i = 0; i < list.Count; i++)
        {
            for (j = i + 1; j < list.Count; j++)
            {
                if (list[i] == list[j])
                {
                    doubling++;
                }
            }
        }
        if (doubling == 1)
        {
            ///ワンペアの場合
            int rankPoint;
            
            int z;
            int pairIndex = 0;
            int pairNum;
            for (z = 0; z < 4; z++)
            {

                if (list[z] == list[z + 1]) // 連番で一致する場所を確認する
                {

                    break;
                }
                pairIndex++; // ペアが存在するインデックスの開始位置
            }
            pairNum = list[pairIndex]; //ペアのナンバー
            list.RemoveAll(p => p == list[pairIndex]);//ナンバーと一致している数を取り除く

            ///rankpoint = 16進法で一桁目がペア、それから大きい順に残りの３つの数字が並ぶ
            rankPoint = 16*16*16 + pairNum * 16 *16 + list[0] *16;
            list = new List<int>() { pairNum, pairNum, list[0]};

            return rankPoint;
        }

        else if (doubling == 3)
        {
            ///スリーカードの場合
            int rankPoint;

            rankPoint = 2 * 16 * 16 * 16 + list[0] * 16 * 16;

            return rankPoint;

        }

        else
        {
            ///豚の場合
            int rankPoint;
            ///rankpoint = 16進法で5桁 0xfffff >  0x11111
            rankPoint = list[0] * 16 * 16 + list[1] * 16 + list[2]  ;

            return rankPoint;
        }
    }

    void sendhandrank(int i)
    {
        i = handRankCalc();
        var properties = new ExitGames.Client.Photon.Hashtable();
        properties.Add(PhotonNetwork.player.ID + "top", i);
        PhotonNetwork.room.SetCustomProperties(properties);
    }
}







