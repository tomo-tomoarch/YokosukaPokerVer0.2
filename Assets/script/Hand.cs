using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{

    GameControler gameControler;


    void Update()
    {
        GameControler gameControler = GameObject.Find("GameControler").GetComponent<GameControler>();
        this.GetComponent<Text>().text = gameControler.screen;

    }
}
