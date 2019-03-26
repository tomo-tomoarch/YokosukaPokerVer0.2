using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomWinner : MonoBehaviour {


    MiddleJudge middleJudge;


    void Update()
    {
        MiddleJudge middleJudge = GameObject.Find("MiddleJudge").GetComponent<MiddleJudge>();
        this.GetComponent<Text>().text = middleJudge.bottomwinner;
    }
}
