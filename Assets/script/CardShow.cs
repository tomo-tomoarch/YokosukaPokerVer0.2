using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardShow : Photon.MonoBehaviour {

    CardModel card;
    DoubleClick doubleclick;

    void Awake()
    {
        card = GetComponent<CardModel>();
        doubleclick = GetComponent<DoubleClick>();
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (doubleclick.clickNum == 2)
        {
            if (stream.isWriting)
            {
                stream.SendNext(card.cardIndex);
            }
            else
            {
                CardModel cardModel = GetComponent<CardModel>();
                cardModel.cardIndex = (int)stream.ReceiveNext();
                cardModel.ToggleFace(true);
            }
        }
        else
        {
            return;
        }
    }
}
