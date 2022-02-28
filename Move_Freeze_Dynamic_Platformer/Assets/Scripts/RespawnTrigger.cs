using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Rook"||other.gameObject.tag == "King"||other.gameObject.tag == "Knight"||other.gameObject.tag == "Bishop")
        {
            other.gameObject.GetComponent<PlayerRespawn>().RepositionPlayer();
        }
    }
}
