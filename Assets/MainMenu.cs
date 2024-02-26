using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Closes the application.
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed.");

    }

    // Starts application by changing game scene.
    public void StartGame()
    {
        SceneManager.LoadScene("snake");
        Debug.Log("Game started.");
    }
   
}
