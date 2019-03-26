using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleRankSender : MonoBehaviour {

    public int[] middleRankhand;
    public GameObject cardPrefab;
  
    public void ResetRank()
    {
        middleRankhand = new int[0] { };
    }


    public void Rank(int i)
    {
        if(middleRankhand.Length >= 5)
        {
            middleRankhand = new int[0] { };
        }
        System.Array.Resize(ref middleRankhand, middleRankhand.Length + 1);
        middleRankhand[middleRankhand.Length - 1] = i;
      
        if(middleRankhand.Length == 5)
        {
            int j;
            for (j = 0; j < middleRankhand.Length; j++)
            {
                var properties = new ExitGames.Client.Photon.Hashtable();
                string card = PhotonNetwork.player.ID + "middleRankhand" + j;
                properties.Add(card, middleRankhand[j]);
                PhotonNetwork.room.SetCustomProperties(properties);
                Debug.Log(card + middleRankhand[j]);
            }
        }
    }
}
