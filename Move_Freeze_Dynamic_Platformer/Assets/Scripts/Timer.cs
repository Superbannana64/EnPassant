using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject canvasObj;
    [SerializeField] private string winScene, startScene;
    private static float timeSpent = 0;
    private string sceneName;
    bool timerRunning = false;
    void Start()
    {
        sceneName= SceneManager.GetActiveScene().name;
        CheckTimer();
    }
    void Update()
    {
        CheckTimer();
        if(timerRunning)
        {
            RunTimer();
            canvasObj.GetComponent<CanvasUpdate>().ChangeTime(timeSpent);
        }
        if(!timerRunning && sceneName == winScene)
        {
            canvasObj.GetComponent<WinScreenScript>().CheckLowHighTime(timeSpent);
            timeSpent = 0;
        }
        else if(!timerRunning)
        {
            timeSpent = 0;
        }
    }
    void CheckTimer()
    {
        if( sceneName == winScene)
        {
            timerRunning = false;
        }
        else if (sceneName == startScene)
        {
            timerRunning = false;
        }
        else
        {
            timerRunning = true;
        }
    }
    void RunTimer()
    {
        timeSpent += Time.deltaTime;
    }
}
