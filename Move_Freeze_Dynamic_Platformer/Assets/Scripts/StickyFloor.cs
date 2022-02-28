using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyFloor : MonoBehaviour
{
    private string slowDown = "OnStickyFloor", speedUp = "OffStickyFloor";
    public float speedChange = 2.0f;
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Rook"||other.gameObject.tag == "King"||other.gameObject.tag == "Knight"||other.gameObject.tag == "Bishop")
        {
            other.gameObject.SendMessage(slowDown, speedChange);
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Rook"||other.gameObject.tag == "King"||other.gameObject.tag == "Knight"||other.gameObject.tag == "Bishop")
        {
            other.gameObject.SendMessage(speedUp, speedChange);
        }
    }
}
