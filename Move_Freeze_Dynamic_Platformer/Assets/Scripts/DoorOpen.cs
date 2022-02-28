using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] GameObject objDoor;
    [SerializeField] private int weightToOpen;
    public bool DoWeight = true;
    private bool correctObj = false;
    private int totalWeight;

    void OnTriggerEnter2D(Collider2D obj)
    {
        CheckObj(obj);
        if(DoWeight && correctObj)
        {
            totalWeight += obj.gameObject.GetComponent<BasicPlayer>().GetWeight();
            if(totalWeight >= weightToOpen)
            {
                objDoor.SetActive(false);
            }
        }
        else
        {
            objDoor.SetActive(false);
        }
    }
    void OnTriggerExit2D(Collider2D obj)
    {
        if(DoWeight)
        {
            totalWeight -= obj.gameObject.GetComponent<BasicPlayer>().GetWeight();
            objDoor.SetActive(true);
        }
        else
        {
            objDoor.SetActive(true);
        }
    }
    private void CheckObj(Collider2D obj)
    {
        if(obj.gameObject.CompareTag("Rook")||obj.gameObject.CompareTag("Bishop")||obj.gameObject.CompareTag("King")||obj.gameObject.CompareTag("Knight"))
        {
            correctObj = true;
        }
        else
        {
            correctObj = false;
        }
    }
}
