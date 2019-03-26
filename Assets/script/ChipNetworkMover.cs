using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipNetworkMover : Photon.MonoBehaviour {

    Vector3 position;
    float smoothing = 1f;


    void Start()
    {
        if (photonView.isMine)
        {
            //GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            GetComponent<mouse>().enabled = false;
            StartCoroutine("UpdateData");
        }
    }
    IEnumerator UpdateData()
    {
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * smoothing);
            yield return null;
        }
    }
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.isWriting)
        {
            stream.SendNext(transform.position);　//現在のポジションを送る
           
        }
        else
        {
            position = (Vector3)stream.ReceiveNext();　//現在のポジションを受信
        }
    }
}
