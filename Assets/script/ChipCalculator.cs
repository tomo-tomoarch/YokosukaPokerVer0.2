using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipCalculator : MonoBehaviour
{

     //chip
    float chipOffset = 0.15f;
    float chiphozOffset = 1.1f;
    public Vector3 startposition;
    string chip;
    int purpleStuckNum;
    int purpleChipNum;
    int blackStuckNum;
    int blackChipNum;
    int totalStuckNum;
    float temp;
    int pokerpoint = 0;
    //chip

    GameObject[] tagObjects100;
    GameObject[] tagObjects500;

    public string screen;
    public string opponentscreen;
    public string tempscreen;
    public string tempopponentscreen;

    void OnJoinedroom()//部屋に入ったら下記を実行
    {
        //room.custom.propertiesにチップの枚数を送る
        var properties = new ExitGames.Client.Photon.Hashtable();
        properties.Add(PhotonNetwork.player.ID + "pokerpoint", pokerpoint);
        PhotonNetwork.room.SetCustomProperties(properties);
        screen = pokerpoint + "point";　//現在のscreenのstring
    }

    void Update()//チップの監視
    {
        tagObjects100 = GameObject.FindGameObjectsWithTag("Hozchip100");//100チップを数える
        tagObjects500 = GameObject.FindGameObjectsWithTag("Hozchip500");//500チップを数える
        pokerpoint = tagObjects100.Length * 100 + tagObjects500.Length * 500;//描画されているチップの枚数
        tempscreen = pokerpoint + "point";//新しいscreenのstring
        

        if (screen != tempscreen)//現在のscreenと新しいscreenに違いがあれば
        {
            if (PhotonNetwork.inRoom == true)
            {
                //データをルームプロパティに送る
                var properties = new ExitGames.Client.Photon.Hashtable();
                properties.Add(PhotonNetwork.player.ID + "pokerpoint", pokerpoint);
                PhotonNetwork.room.SetCustomProperties(properties);


                if (PhotonNetwork.player.ID == 1)
                {
                    if (PhotonNetwork.room.customProperties[2 + "pokerpoint"] != null)
                    {
                        opponentscreen = (int)PhotonNetwork.room.customProperties[2 + "pokerpoint"] + "point";
                    }

                }
                else 
                {
                    if (PhotonNetwork.room.customProperties[1 + "pokerpoint"] != null)
                    {
                        opponentscreen = (int)PhotonNetwork.room.customProperties[1 + "pokerpoint"] + "point";
                    }
                }
            }
            screen = tempscreen;
        }
    }

    void OnPhotonCustomRoomPropertiesChanged()//逆のプレイヤーがチップを更新した時の処理
    {
        if (PhotonNetwork.player.ID == 1)
        {
            if (PhotonNetwork.room.customProperties[2 + "pokerpoint"] != null)
            {
                opponentscreen = (int)PhotonNetwork.room.customProperties[2 + "pokerpoint"] + "point";
            }

        }
        else
        {
            if (PhotonNetwork.room.customProperties[1 + "pokerpoint"] != null)
            {
                opponentscreen = (int)PhotonNetwork.room.customProperties[1 + "pokerpoint"] + "point";
            }
        }
    }




    public int ChipCountShow()
    {
        return pokerpoint;
    }

    public void ChipShow(int money, int neg)//チップをレンダーの処理
    {
        temp = startposition.x;
        startposition.x = neg * temp;

        if (money - 3000 < 0)
        {
            blackStuckNum = money / 1000;
            blackChipNum = (money % 1000) / 100;
            purpleStuckNum = 0;
            purpleChipNum = 0;
        }
        else if (money / 3000 > 0)
        {
            purpleStuckNum = (money - 3000) / 5000;
            purpleChipNum = ((money - 3000) % 5000) / 500;
            blackStuckNum = 3;
            blackChipNum = (money - (5000 * purpleStuckNum) - (purpleChipNum * 500) - 3000) / 100;
        }


        int k;
        int j;
        if (purpleStuckNum > 0)
        {
            for (j = 0; j < purpleStuckNum; j++)
            {
                float coh = neg* chiphozOffset * j; //水平オフセット幅の計算
                totalStuckNum++;

                for (k = 0; k < 10; k++)
                {
                    float co = chipOffset * k; //縦オフセット幅の計算
                    Vector3 temp = startposition + new Vector3(-coh, co);//tempというオフセットした位置の計算
                    GameObject pokerchip = (GameObject)PhotonNetwork.Instantiate("pokerchip3", temp, Quaternion.identity, 0);
                }
            }
        }
        if (purpleChipNum > 0)
        {
            for (j = 0; j < 1; j++)
            {
                float coh = neg * chiphozOffset * totalStuckNum; //水平オフセット幅の計算
                totalStuckNum++;
                for (k = 0; k < purpleChipNum; k++)
                {
                    float co = chipOffset * k; //縦オフセット幅の計算
                    Vector3 temp = startposition + new Vector3(-coh, co);//tempというオフセットした位置の計算
                    GameObject pokerchip = (GameObject)PhotonNetwork.Instantiate("pokerchip3", temp, Quaternion.identity, 0);
                }
            }
        }
        for (j = 0; j < blackStuckNum; j++)
        {
            float coh = neg * chiphozOffset * totalStuckNum; //水平オフセット幅の計算
            totalStuckNum++;

            for (k = 0; k < 10; k++)
            {
                float co = chipOffset * k; //縦オフセット幅の計算
                Vector3 temp = startposition + new Vector3(-coh, co);//tempというオフセットした位置の計算
                GameObject pokerchip = (GameObject)PhotonNetwork.Instantiate("pokerchip4", temp, Quaternion.identity, 0);
            }
        }
        if (blackChipNum > 0)
        {
            for (j = 0; j < 1; j++)
            {
                float coh = neg * chiphozOffset * totalStuckNum; //水平オフセット幅の計算
                totalStuckNum++;
                for (k = 0; k < blackChipNum; k++)
                {
                    float co = chipOffset * k; //縦オフセット幅の計算
                    Vector3 temp = startposition + new Vector3(-coh, co);//tempというオフセットした位置の計算
                    GameObject pokerchip = (GameObject)PhotonNetwork.Instantiate("pokerchip4", temp, Quaternion.identity, 0);
                }
            }
        }
    }
}

   
