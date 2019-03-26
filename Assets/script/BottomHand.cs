using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomHand : MonoBehaviour {


    BottomGameControler bottomGameControler;


    void Update()
    {
        BottomGameControler bottomGameControler = GameObject.Find("BottomGameControler").GetComponent<BottomGameControler>();
        this.GetComponent<Text>().text = bottomGameControler.screen;

    }
}
