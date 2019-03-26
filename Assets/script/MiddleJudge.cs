using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleJudge : MonoBehaviour {

    public GameControler gameControler;
    public string winner;
    public string bottomwinner;
    public string topwinner;

    double Myhand;
    double Yourhand;

    double Mybottomhand;
    double Yourbottomhand;

    int Mytophand;
    int Yourtophand;

    private void Awake()
    {
        gameControler = GetComponent<GameControler>();
    }

    void OnGUI()
    {
      
            if (GUI.Button(new Rect(380, 100, 256, 28), "Judge"))
            {
                //HITMEを押したら下記を実行

                if (PhotonNetwork.player.ID == 1)
                {
                    Myhand = (double)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "middle"];
                    Yourhand = (double)PhotonNetwork.room.customProperties[2 + "middle"];
                    Mybottomhand = (double)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "bottom"];
                    Yourbottomhand = (double)PhotonNetwork.room.customProperties[2 + "bottom"];
                    Mytophand = (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "top"];
                    Yourtophand = (int)PhotonNetwork.room.customProperties[2 + "top"];
                }
                else
                {
                    Myhand = (double)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "middle"];
                    Yourhand = (double)PhotonNetwork.room.customProperties[1 + "middle"];
                    Mybottomhand = (double)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "bottom"];
                    Yourbottomhand = (double)PhotonNetwork.room.customProperties[1 + "bottom"];
                    Mytophand = (int)PhotonNetwork.room.customProperties[PhotonNetwork.player.ID + "top"];
                    Yourtophand = (int)PhotonNetwork.room.customProperties[1 + "top"];
                }

                if (Myhand >= Yourhand)
                {
                    winner = "You win!";
                }
                else
                {
                    winner = "You lose!";
                }
                if (Mybottomhand >= Yourbottomhand)
                {
                    bottomwinner = "You win!";
                }
                else
                {
                    bottomwinner = "You lose!";
                }
                if (Mytophand >= Yourtophand)
                {
                    topwinner = "You win!";
                }
                else
                {
                    topwinner = "You lose!";
                }
            }
        
    }
}
