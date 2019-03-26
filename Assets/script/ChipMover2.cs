using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipMover2 : MonoBehaviour {

    public GameObject destination;
    public GameObject destination2;
    public float accelerationScale;
    float timer = 1.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("100Chip") || other.gameObject.CompareTag("500Chip"))
        {
            //other.gameObject.SetActive(false); //ぶつかった相手をディアクティベート（消える
            //other.isTrigger = false;

            //FoldButton foldButton = GameObject.Find("FoldButton").GetComponent<FoldButton>();

            if ((int)PhotonNetwork.room.customProperties["middlefoldPlayer"] == 2)
            {
                var direction = destination.transform.position - other.transform.position;
                direction.Normalize();
                Rigidbody2D rigidbody2D = other.GetComponent<Rigidbody2D>();
                rigidbody2D.AddForce(accelerationScale * direction, ForceMode2D.Force);
                Destroy(gameObject, timer);
            }
            else
            {
                var direction = destination2.transform.position - other.transform.position;
                direction.Normalize();
                Rigidbody2D rigidbody2D = other.GetComponent<Rigidbody2D>();
                rigidbody2D.AddForce(accelerationScale * direction, ForceMode2D.Force);
                Destroy(gameObject, timer);
            }
        }
    }
}
