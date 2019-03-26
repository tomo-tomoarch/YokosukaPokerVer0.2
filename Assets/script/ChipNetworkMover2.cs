using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipNetworkMover2 : Photon.MonoBehaviour {

    
    Vector3 position;
    float smoothing = 1f;


    void Start()
    {
        if (photonView.isMine != true)
        {
            GetComponent<Chipcreate2>().enabled = false;
            gameObject.tag = "Untagged";
        }
    }
    /*
    else
    {
        StartCoroutine("UpdateData");
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
    */
}
