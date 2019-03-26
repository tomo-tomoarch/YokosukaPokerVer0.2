using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipNetworkMover3 : Photon.MonoBehaviour
{
    void Start()
    {
        if (photonView.isMine != true)
        {
            GetComponent<ChipCreate>().enabled = false;
            gameObject.tag = "Untagged";
        }
    }
}
