using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pokepoint2 : MonoBehaviour {

    ChipCalculator chipCalculator;
    float temp;
    Vector3 current;

    void OnPhotonCustomRoomPropertiesChanged()
    {
        if (PhotonNetwork.player.ID == 1)
        {
            ChipCalculator chipCalculator = GameObject.Find("ChipCalc").GetComponent<ChipCalculator>();
            this.GetComponent<Text>().text = chipCalculator.opponentscreen;
        }
        else
        {
            ChipCalculator chipCalculator = GameObject.Find("ChipCalc").GetComponent<ChipCalculator>();
            this.GetComponent<Text>().text = chipCalculator.screen;
        }

    }
}
