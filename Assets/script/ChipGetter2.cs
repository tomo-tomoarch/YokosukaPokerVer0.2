using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipGetter2 : MonoBehaviour
{
        public ChipCalculator chipCalculator;
        public Vector3 temp;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("100Chip"))
            {
                Destroy(other.gameObject); //ぶつかった相手をディアクティベート（消える
                if (PhotonNetwork.player.ID == 1)
                {
                    GameObject pokerchip = (GameObject)PhotonNetwork.Instantiate("pokerchip4", temp, Quaternion.identity, 0);
                }

            }
            else if (other.gameObject.CompareTag("500Chip"))
            {
                Destroy(other.gameObject); //ぶつかった相手をディアクティベート（消える
                if (PhotonNetwork.player.ID == 1)
                {
                    GameObject pokerchip = (GameObject)PhotonNetwork.Instantiate("pokerchip3", temp, Quaternion.identity, 0);
                }
            }
        }

}