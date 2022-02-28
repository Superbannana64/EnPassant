using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector2 origPlayerPosition;
    void Start()
    {
        origPlayerPosition = transform.localPosition;
        Debug.Log(origPlayerPosition);
    }
    public void NewPosition()
    {
        origPlayerPosition = transform.localPosition;
    }
    public void RepositionPlayer()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.localPosition = origPlayerPosition;
    }
}
