using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameButton : MonoBehaviour
{
    public void doExitGame()
    {
        Application.Quit();
        Debug.Log("Quitting the Application");
    }
}
