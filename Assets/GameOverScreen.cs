using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverScreen;
   
    public GameObject scoreGameObject;

    public GameObject mainMenuButton;

    public Snake snake;

    public void Setup(int score)
    {
        gameOverScreen.SetActive(true);

        if (scoreGameObject != null)
        {
            // sets end score on game over screen
            scoreGameObject.GetComponent<TextMeshProUGUI>().SetText("Final Score: " + score.ToString());
        }
    }

    public void RestartButton()
    {
        gameOverScreen.SetActive(false);
        snake.ResetState();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
