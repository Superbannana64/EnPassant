using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperyFloor : MonoBehaviour
{
    private string slowDown = "OffSlipperyFloor", speedUp = "OnSlipperyFloor";
    public float speedChange = 2.0f;
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Rook"||other.gameObject.tag == "King"||other.gameObject.tag == "Knight"||other.gameObject.tag == "Bishop")//Sloppy Code Alert
        {
            other.gameObject.SendMessage(speedUp, speedChange);
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Rook"||other.gameObject.tag == "King"||other.gameObject.tag == "Knight"||other.gameObject.tag == "Bishop")
        {
            other.gameObject.SendMessage(slowDown, speedChange);
        }
    }
}
