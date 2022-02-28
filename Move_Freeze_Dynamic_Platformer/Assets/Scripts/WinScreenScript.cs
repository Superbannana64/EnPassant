using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class WinScreenScript : MonoBehaviour
{
    [SerializeField] private GameObject scorePrefab;
    [SerializeField] private Vector2 star1, star2, star3;
    public float lowestTime, highTime;
    bool setStar = false;
    public TextMeshProUGUI timerText;
    public void CheckLowHighTime(float time)
    {
        if(!setStar)
        {
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);
            timerText.text = "Time: "+ string.Format("{0:00}:{1:00}", minutes, seconds);

            if(time < lowestTime)
            {
                Instantiate(scorePrefab, star1, Quaternion.identity);
                Instantiate(scorePrefab, star2, Quaternion.identity);
                Instantiate(scorePrefab, star3, Quaternion.identity);
                setStar = true;
            }
            else if(time > lowestTime && time < highTime)
            {
                Instantiate(scorePrefab, star1, Quaternion.identity);
                Instantiate(scorePrefab, star2, Quaternion.identity);
                setStar = true;
            }
            else
            {
                Instantiate(scorePrefab, star1, Quaternion.identity);
                setStar = true;
            }
        }
    }
}
