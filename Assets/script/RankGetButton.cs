using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankGetButton : MonoBehaviour {

    public MiddleRankSender middleRankSender;
    public BottomRankSender bottomRankSender;
    public TopRankSender topRankSender;
    public GameObject MiddleRankGet;
    public GameObject BottomRankGet;
    public GameObject TopRankGet;
    public Vector3 position;
    public Vector3 bottomposition;
    public Vector3 topposition;
    int buttonX;
    float buttonPosition;
    public bool bottom;
    public bool middle;
    public bool top;
    public bool flipflip;

    void OnJoinedRoom()
    {
        bottom = false;
        middle = false;
        top = false;
        flipflip = false;

        if (PhotonNetwork.player.ID == 1)
        {
            buttonPosition = 4.71f;
            buttonX = 750;
        }
        else
        {
            buttonPosition = -4.91f;
            buttonX = 20;
        }
    }

    void OnGUI()
    {
        
        if (GUI.Button(new Rect(buttonX, 20, 256, 28), "I'm ready!"))  //HITMEを押したら下記を実行
        {
            middleRankSender.ResetRank();
            GameObject middleRankGet = (GameObject)Instantiate(MiddleRankGet);  // カードをコピー
            position = new Vector3(buttonPosition, 0.92f, 0);
            middleRankGet.transform.position = position;   //コピーしたカードのポジションを移動　値は position

            bottomRankSender.ResetRank();
            GameObject bottomRankGet = (GameObject)Instantiate(BottomRankGet);  // カードをコピー
            bottomposition = new Vector3(buttonPosition, -2.04f, 0);
            bottomRankGet.transform.position = bottomposition;   //コピーしたカードのポジションを移動　値は position

            topRankSender.ResetRank();
            GameObject topRankGet = (GameObject)Instantiate(TopRankGet);  // カードをコピー
            topposition = new Vector3(buttonPosition, 3.95f, 0);
            topRankGet.transform.position = topposition;   //コピーしたカードのポジションを移動　値は position

            bottom = true;
            middle = true;
            top = true;
            flipflip = true;
        }
    }

    public bool ToggleReadyBottom()
    {
        return bottom;
    }
    public bool ToggleReadyMiddle()
    {
        return middle;
    }
    public bool ToggleReadyTop()
    {
        return top;
    }
    public bool ToggleMouseOver()
    {
        return flipflip;
    }
}
