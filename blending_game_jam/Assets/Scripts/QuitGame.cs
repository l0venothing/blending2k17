using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void ExitButton()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }
}
