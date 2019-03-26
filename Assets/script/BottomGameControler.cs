using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomGameControler : MonoBehaviour {
    //public MiddleRankSender middleRankSender;
    RankGetButton rankGetButton;
    public int[] handRank;
    public int[] handNumber;
    public int[] handSuite;

    GameObject[] tagObjects;

    int buttonX;

    public string screen;


    private void Awake()
    {
        handRank = new int[5] { 0, 0, 0, 0, 0 };
        rankGetButton = GameObject.Find("RankGetButton").GetComponent<RankGetButton>();
    }
    private void Update()
    {
        //tagObjects = GameObject.FindGameObjectsWithTag("bar");
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
        if (rankGetButton.ToggleReadyBottom())
        {
        if (GUI.Button(new Rect(buttonX, 420, 100, 28), "check hand!!"))
            {

                int rank = (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "bottomRankhand0"];
                int rankB = (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "bottomRankhand1"];
                int rankC = (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "bottomRankhand2"];
                int rankD = (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "bottomRankhand3"];
                int rankE = (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "bottomRankhand4"];

                handRank = new int[5] { rank, rankB, rankC, rankD, rankE }; //リストの作成

                rankGetButton.bottom = false;



                if (rank == rankB || rankB == rankC || rankC == rankD || rankD == rankE || rankE == rank)
                {
                    Debug.Log("You got short hand, put more cards.");
                    screen = "You got short hand, put more cards.";

                }
                else if (handRankCalc() > System.Math.Pow(16, 12))
                {
                    Debug.Log("You got straight flush !!!" + handRankCalc());
                    screen = "You got straight flush !!! " + handRankCalc();
                    sendhandrank(handRankCalc());
                }
                else if (handRankCalc() > System.Math.Pow(16, 11))
                {
                    Debug.Log("You got 4 of a kind !!!" + handRankCalc());
                    screen = "You got 4 of a kind !!! " + handRankCalc();
                    sendhandrank(handRankCalc());
                }
                else if (handRankCalc() > System.Math.Pow(16, 10))
                {
                    Debug.Log("You got full house!" + handRankCalc());
                    screen = "You got full house!!  " + handRankCalc();
                    sendhandrank(handRankCalc());
                }
                else if (handRankCalc() > System.Math.Pow(16, 9))
                {
                    Debug.Log("You got flush  ! " + handRankCalc());
                    screen = "You got flush  !! " + handRankCalc();
                    sendhandrank(handRankCalc());
                }
                else if (handRankCalc() > System.Math.Pow(16, 8))
                {
                    Debug.Log("You got straight !" + handRankCalc());
                    screen = "You got straight !" + handRankCalc();
                    sendhandrank(handRankCalc());
                }
                else if (handRankCalc() > System.Math.Pow(16, 7))
                {
                    Debug.Log("You got 3 of a kind! " + handRankCalc());
                    screen = "You got 3 of a kind!" + handRankCalc();
                    sendhandrank(handRankCalc());
                }
                else if (handRankCalc() > System.Math.Pow(16, 6))
                {
                    Debug.Log("You got two pair!" + handRankCalc());
                    screen = "You got two pair! " + handRankCalc();
                    sendhandrank(handRankCalc());
                }
                else if (handRankCalc() > System.Math.Pow(16, 5))
                {
                    Debug.Log("You got one pair" + handRankCalc());
                    screen = "You got one pair" + handRankCalc();
                    sendhandrank(handRankCalc());
                }
                else if (handRankCalc() > System.Math.Pow(16, 4))
                {
                    string i;
                    Debug.Log("you are pig." + handRankCalc());
                    i = "you are pig." + handRankCalc().ToString();
                    screen = i;
                    sendhandrank(handRankCalc());
                }
                else
                {
                    Debug.Log("You are mistery, report this bug");
                    screen = "You are mistery, report this bug";
                }
            }
        }

    }

    /// <summary>
    /// handRankCalc ここから
    /// </summary>
    /// 
    /// <returns></returns>


    ///memo //16進法をintからstringに書き直すやり方
    //string str = Convert.ToString(num, 16) 


    public double handRankCalc()
    {
        int total = 0;
        int k;
        int l;


        handNumber = new int[5] { 0, 0, 0, 0, 0 };

        for (k = 0; k < 5; k++)
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

        handSuite = new int[5] { 0, 0, 0, 0, 0 };
        for (l = 0; l < 5; l++)
        {
            handSuite[l] = handRank[l] / 13;
        }

        var list = new List<int>();
        list.AddRange(handNumber);
        list.Sort();
        list.Reverse();

        /*リストを確かめる
         foreach (int num in list)
         {
             Debug.Log(num);
         }
         */

        HashSet<int> pairChecker = new HashSet<int>() { handNumber[0], handNumber[1], handNumber[2], handNumber[3], handNumber[4] };

        if (handSuite[0] == handSuite[1] && handSuite[1] == handSuite[2] && handSuite[2] == handSuite[3] && handSuite[3] == handSuite[4])
        {
            if (list[0] == 14 && list[1] == 5 && list[2] == 4 && list[3] == 3 && list[4] == 2)
            {
                ///弱いストレートフラッシュの場合
                double rankPoint;
                double ko;

                ///べき乗の書き方             
                ko = System.Math.Pow(16, 12);
                rankPoint = 3 * ko;

                return rankPoint;
            }

            else if ((list[0] + list[1] + list[2] + list[3] + list[4]) / 5 == list[2] && list[2] - 2 == list[4] && list[2] + 2 == list[0])
            {
                ///強いストレートフラッシュの場合
                double rankPoint;
                double ko;

                ///べき乗の書き方             
                ko = System.Math.Pow(16, 12);
                rankPoint = list[2] * ko;

                return rankPoint;
            }
            else
            {
                ///フラッシュの場合
                double rankPoint;
                double d;
                double e;
                double f;
                double g;
                double h;
                ///べき乗の書き方             
                d = System.Math.Pow(16, 5);
                e = System.Math.Pow(16, 6);
                f = System.Math.Pow(16, 7);
                g = System.Math.Pow(16, 8);
                h = System.Math.Pow(16, 9);

                ///rankpoint = 16進法で9桁 0xfffff >  0x11111
                rankPoint = list[0] * h + list[1] * g + list[2] * f + list[3] * e + list[4] * d;

                return rankPoint;
            }


        }
        else if (pairChecker.Count < 5)
        {
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
                double rankPoint;
                double b;
                double c;
                double d;
                double e;
                ///べき乗の書き方              
                b = System.Math.Pow(16, 2);
                c = System.Math.Pow(16, 3);
                d = System.Math.Pow(16, 4);
                e = System.Math.Pow(16, 5);

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
                pairNum = list[pairIndex];　//ペアのナンバー
                list.RemoveAll(p => p == list[pairIndex]);//ナンバーと一致している数を取り除く


                ///rankpoint = 16進法で一桁目がペア、それから大きい順に残りの３つの数字が並ぶ
                rankPoint = pairNum * e + list[0] * d + list[1] * c + list[2] * b;
                list = new List<int>() { pairNum, pairNum, list[0], list[1], list[2] };
                /*
                Debug.Log("pair"+ pairNum);
                Debug.Log(list[0]);
                Debug.Log(list[1]);
                Debug.Log(list[2]);
                */

                return rankPoint;

            }
            else if (doubling == 2)
            {
                ///ツーペアの場合
                double rankPoint;
                double d;
                double e;
                double f;

                ///べき乗の書き方             
                d = System.Math.Pow(16, 4);
                e = System.Math.Pow(16, 5);
                f = System.Math.Pow(16, 6);


                int m;
                int pairIndexA = 0;
                int pairNumA;
                for (m = 0; m < 4; m++)
                {

                    if (list[m] == list[m + 1]) // 連番で一致する場所を確認する
                    {

                        break;
                    }
                    pairIndexA++; // 一個目の大きいペアが存在するインデックスの開始位置
                }
                pairNumA = list[pairIndexA];　//ペアのナンバー
                list.RemoveAll(p => p == pairNumA);//ナンバーと一致している数を取り除く



                int n;
                int pairIndexB = 0;
                int pairNumB;
                for (n = 0; n < 2; n++)
                {
                    if (list[n] == list[n + 1]) // 残りの3つの数から連番で一致する場所を確認する
                    {

                        break;
                    }
                    pairIndexB++; // 二個目の小さいペアが存在するインデックスの開始位置
                }
                pairNumB = list[pairIndexB];　//ペアのナンバー
                list.RemoveAll(p => p == list[pairIndexB]);//ナンバーと一致している数を取り除く

                ///rankpoint = 16進法で一桁目がペア、それから大きい順に残りの数字が1つ
                rankPoint = pairNumA * f + pairNumB * e + list[0] * d;
                list = new List<int>() { pairNumA, pairNumA, pairNumB, pairNumB, list[0] };

                return rankPoint;

            }
            else if (doubling == 3)
            {

                ///スリーカードの場合
                double rankPoint;
                double e;
                double f;
                double g;

                ///べき乗の書き方             

                e = System.Math.Pow(16, 5);
                f = System.Math.Pow(16, 6);
                g = System.Math.Pow(16, 7);

                int m;
                int pairIndexA = 0;
                int pairNumA;
                for (m = 0; m < 4; m++)
                {

                    if (list[m] == list[m + 1] && list[m + 1] == list[m + 2]) // 連番で一致する場所を確認する
                    {

                        break;
                    }
                    pairIndexA++; // 一個目の大きいペアが存在するインデックスの開始位置
                }
                pairNumA = list[pairIndexA];　//ペアのナンバー
                list.RemoveAll(p => p == pairNumA);//ナンバーと一致している数を取り除く

                rankPoint = pairNumA * g + list[0] * f + list[1] * e;
                list = new List<int>() { pairNumA, pairNumA, pairNumA, list[0], list[1] };


                return rankPoint;

            }
            else if (doubling == 4)
            {
                ///フルハウスの場合
                double rankPoint;
                double h;
                double io;

                ///べき乗の書き方             

                h = System.Math.Pow(16, 9);
                io = System.Math.Pow(16, 10);

                int m;
                int pairIndexA = 0;
                int pairNumA;
                for (m = 0; m < 4; m++)
                {

                    if (list[m] == list[m + 1] && list[m + 1] == list[m + 2]) // 連番で一致する場所を確認する
                    {

                        break;
                    }
                    pairIndexA++; // 一個目の大きいペアが存在するインデックスの開始位置
                }
                pairNumA = list[pairIndexA];　//ペアのナンバー
                list.RemoveAll(p => p == pairNumA);//ナンバーと一致している数を取り除く

                rankPoint = pairNumA * io + list[0] * h;
                list = new List<int>() { pairNumA, pairNumA, pairNumA, list[0], list[0] };

                return rankPoint;

            }
            else if (doubling == 6)
            {
                ///フォーカードの場合
                double rankPoint;
                double io;
                double jo;

                ///べき乗の書き方             
                io = System.Math.Pow(16, 10);
                jo = System.Math.Pow(16, 11);

                int m;
                int pairIndexA = 0;
                int pairNumA;
                for (m = 0; m < 4; m++)
                {

                    if (list[m] == list[m + 1] && list[m + 1] == list[m + 2] && list[m + 2] == list[m + 3]) // 連番で一致する場所を確認する
                    {

                        break;
                    }
                    pairIndexA++; // 一個目の大きいペアが存在するインデックスの開始位置
                }
                pairNumA = list[pairIndexA];　//ペアのナンバー
                list.RemoveAll(p => p == pairNumA);//ナンバーと一致している数を取り除く

                rankPoint = pairNumA * jo + list[0] * io;
                list = new List<int>() { pairNumA, pairNumA, pairNumA, pairNumA, list[0] };

                return rankPoint;
            }
            else
            {
                return 9;
            }

        }

        else if (list[0] == 14 && list[1] == 5 && list[2] == 4 && list[3] == 3 && list[4] == 2)
        {
            ///弱いストレートの場合
            double rankPoint;
            double h;

            ///べき乗の書き方             
            h = System.Math.Pow(16, 8);
            rankPoint = 3 * h;

            return rankPoint;
        }

        else if ((list[0] + list[1] + list[2] + list[3] + list[4]) / 5 == list[2] && list[2] - 2 == list[4] && list[2] + 2 == list[0])
        {
            ///強いストレートの場合
            double rankPoint;
            double h;

            ///べき乗の書き方             
            h = System.Math.Pow(16, 8);
            rankPoint = list[2] * h;

            Debug.Log(h);

            return rankPoint;
        }


        else
        {
            ///豚の場合
            double rankPoint;
            double a;
            double b;
            double c;
            double d;
            ///べき乗の書き方
            a = System.Math.Pow(16, 1);
            b = System.Math.Pow(16, 2);
            c = System.Math.Pow(16, 3);
            d = System.Math.Pow(16, 4);
            ///rankpoint = 16進法で5桁 0xfffff >  0x11111
            rankPoint = list[0] * d + list[1] * c + list[2] * b + list[3] * a + list[4];

            return rankPoint;
        }

    }

    void sendhandrank(double i)
    {
        var properties = new ExitGames.Client.Photon.Hashtable();
        properties.Add(PhotonNetwork.player.ID + "bottom", i);
        PhotonNetwork.room.SetCustomProperties(properties);
    }

}
