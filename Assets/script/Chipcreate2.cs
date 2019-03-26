using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Chipcreate2 : MonoBehaviour,IPointerClickHandler
{

    public int clickNum = 0; //外部参照用のクリック数の宣言
    Vector3 temp;
    Vector3 position;

    private PhotonView m_photonView = null; //RPCを使うときに書き加える

    void Awake()
    {
        m_photonView = GetComponent<PhotonView>();//RPCを使うときに書き加える
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount > 1)
        {
            //Debug.Log(eventData.clickCount);
            temp = this.transform.position;
            GameObject pokerchip = (GameObject)PhotonNetwork.Instantiate("pokerchip", temp, Quaternion.identity, 0);
            m_photonView.RPC("DestroyChip", PhotonTargets.All);
        }
    }

    [PunRPC]
    private void DestroyChip()
    {
        Destroy(gameObject);
    }

}
