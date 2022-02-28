using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasUpdate : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public void ChangeTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timerText.text = "Timer: "+ string.Format("{0:00}:{1:00}", minutes, seconds);
        //timerText.text = time.ToString();
    }
}
