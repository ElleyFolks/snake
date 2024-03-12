using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 * Main menu class that either starts the game or closes the application.
 */
public class MainMenu : MonoBehaviour
{
    /*
     * On action, will close the application.
     */
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed.");

    }

    /*
     * On action, will start application by changing game scene.
     */
    public void StartGame()
    {
        SceneManager.LoadScene("snake");
        Debug.Log("Game started.");
    }
   
}
