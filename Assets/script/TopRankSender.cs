using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopRankSender : MonoBehaviour
{
    public int[] topRankhand;
    public GameObject cardPrefab;

    public void ResetRank()
    {
        topRankhand = new int[0] { };
    }

    public void Rank(int i)
    {
        if(topRankhand.Length >= 3)
        {
            topRankhand = new int[0] { };
        }
        System.Array.Resize(ref topRankhand, topRankhand.Length + 1);
        topRankhand[topRankhand.Length - 1] = i;

        if ( topRankhand.Length == 3)
        {
            int j;
            for (j = 0; j < topRankhand.Length; j++)
            {
                var properties = new ExitGames.Client.Photon.Hashtable();
                string card = PhotonNetwork.player.ID + "topRankhand" + j;
                properties.Add(card, topRankhand[j]);
                PhotonNetwork.room.SetCustomProperties(properties);
                Debug.Log(card + topRankhand[j]);
            }
        }
    }
}
