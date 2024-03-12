using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * Class that controlls behavior of game over screen GUI.
 */
public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverScreen;
   
    public GameObject scoreGameObject;

    public GameObject mainMenuButton;

    public Snake snake;

    /*
     * Sets the game over screen to be active. Displays the final score to user.
     */
    public void Setup(int score)
    {
        gameOverScreen.SetActive(true);

        if (scoreGameObject != null)
        {
            // sets end score on game over screen
            scoreGameObject.GetComponent<TextMeshProUGUI>().SetText("Final Score: " + score.ToString());
        }
    }


    /*
     * On action will hide the game over screen, and reset the game state to start over again.
     */
    public void RestartButton()
    {
        gameOverScreen.SetActive(false);
        snake.ResetState();
    }


    /*
     * On action will change scene to main menu.
     */
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
