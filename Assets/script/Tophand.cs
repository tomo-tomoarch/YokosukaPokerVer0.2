using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tophand : MonoBehaviour {


    TopGameControler topGameControler;


    void Update()
    {
        TopGameControler topGameControler = GameObject.Find("TopGameControler").GetComponent<TopGameControler>();
        this.GetComponent<Text>().text = topGameControler.hand;

    }
}
