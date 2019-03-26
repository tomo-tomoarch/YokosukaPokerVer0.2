using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChipCreate : MonoBehaviour, IPointerClickHandler
{
    ChipCalculator chipCalculator;

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
            temp = this.transform.position;
            GameObject pokerchip = (GameObject)PhotonNetwork.Instantiate("pokerchip2", temp, Quaternion.identity, 0);
            m_photonView.RPC("DestroyChip", PhotonTargets.All);//RPCを実行
        }
    }
    [PunRPC] //RPC本体
    private void DestroyChip()
    {
        Destroy(gameObject);
    }
}
