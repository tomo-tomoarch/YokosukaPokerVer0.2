using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoldButton : MonoBehaviour {

    public GameObject foldArea;
    int buttonX;
    float buttonPosition;
    public Vector3 temp;
    public Vector3 middletemp;
    public Vector3 toptemp;
    public int foldPlayer;
    public int middlefoldPlayer;
    public int topfoldPlayer;

    void OnJoinedRoom()
    {
        if (PhotonNetwork.player.ID == 1)
        {
            buttonPosition = 4.71f;
            buttonX = 980;
        }
        else
        {
            buttonPosition = -4.91f;
            buttonX = 10;
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(buttonX, 460, 35, 90), "fold"))  //HITMEを押したら下記を実行
        {
            GameObject foldArea = (GameObject)PhotonNetwork.Instantiate("FoldArea", temp, Quaternion.identity, 0);
            foldPlayer = PhotonNetwork.player.ID;
            var properties = new ExitGames.Client.Photon.Hashtable();
            properties.Add("foldPlayer", foldPlayer);
            PhotonNetwork.room.SetCustomProperties(properties);
        }

        if (GUI.Button(new Rect(buttonX, 285, 35, 90), "fold"))  //HITMEを押したら下記を実行
        {
            GameObject foldArea = (GameObject)PhotonNetwork.Instantiate("MiddleFoldArea", middletemp, Quaternion.identity, 0);
            middlefoldPlayer = PhotonNetwork.player.ID;
            var properties = new ExitGames.Client.Photon.Hashtable();
            properties.Add("middlefoldPlayer", middlefoldPlayer);
            PhotonNetwork.room.SetCustomProperties(properties);
        }

        if (GUI.Button(new Rect(buttonX, 110, 35, 90), "fold"))  //HITMEを押したら下記を実行
        {
            GameObject foldArea = (GameObject)PhotonNetwork.Instantiate("TopFoldArea", toptemp, Quaternion.identity, 0);
            topfoldPlayer = PhotonNetwork.player.ID;
            var properties = new ExitGames.Client.Photon.Hashtable();
            properties.Add("topfoldPlayer", topfoldPlayer);
            PhotonNetwork.room.SetCustomProperties(properties);
        }
    }
}
