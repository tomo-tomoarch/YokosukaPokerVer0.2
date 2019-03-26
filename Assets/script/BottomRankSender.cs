using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomRankSender : MonoBehaviour {

    public int[] bottomRankhand;
    public GameObject cardPrefab;
    int k = 0;

    public void ResetRank()
    {
        bottomRankhand = new int[0] { };
    }


    public void Rank(int i)
    {
         if(bottomRankhand.Length >= 5)
        {
            bottomRankhand = new int[0] { };
        }
        System.Array.Resize(ref bottomRankhand, bottomRankhand.Length + 1);
        bottomRankhand[bottomRankhand.Length - 1] = i;
        
        if(bottomRankhand.Length == 5)
        {
            int j;
            for (j = 0; j < bottomRankhand.Length; j++)
            {
                var properties = new ExitGames.Client.Photon.Hashtable();
                string card = PhotonNetwork.player.ID + "bottomRankhand" + j;
                properties.Add(card, bottomRankhand[j]);
                PhotonNetwork.room.SetCustomProperties(properties);
                Debug.Log(card + bottomRankhand[j]);
            }
        }
    }
}
