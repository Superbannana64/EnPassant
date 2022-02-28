using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    GameObject winObject;
    [SerializeField] private GameObject winCharacter;
    private string winObjectTag;
    [SerializeField] private int sceneNum;
    void Start()
    {
        //winObject = GameObject.FindGameObjectWithTag(winCharacter);
        //winObjectTag=winObject.tag;
        Debug.Log(winObjectTag);
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if(collide.gameObject.tag == "King")
        {
            SceneManager.LoadScene(sceneNum);
        }
    }
}
