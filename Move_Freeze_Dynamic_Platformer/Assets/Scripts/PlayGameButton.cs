using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameButton : MonoBehaviour
{
    public static void changemenuscene(int scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
