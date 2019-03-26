using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipBetter : MonoBehaviour {

    public GameObject pokerchip;
    //public Transform cube;
    float chipOffset;
    public Vector3 startposition;


    // Use this for initialization
    void Start () {
        int i;
        for (i = 0; i < 10; i++)
        {
            float co = chipOffset * i; //オフセット幅の計算
            Vector3 temp = startposition + new Vector3(0f, -co);//tempというオフセットした位置の計算
            GameObject pokerchip = (GameObject)PhotonNetwork.Instantiate("pokerchip", temp, Quaternion.identity, 0);
        }
        

    }

}
