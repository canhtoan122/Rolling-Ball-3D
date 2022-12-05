using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Controller : MonoBehaviour
{
    public Text hpText;
    public Text scoreText;

    public Button pauseButton;
    public GameObject pausePanel;
    public void Update()
    {
        hpText.text = GameManager.lifes.ToString();
        scoreText.text = GameManager.currentScore.ToString();
    }
    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.LoadLevel("Account");
        Time.timeScale = 1f;
    }
    public void Level2TryAgain()
    {
        Application.LoadLevel("Level_2");
        Time.timeScale = 1f;
    }
    public void backtoMenu()
    {
        Application.LoadLevel("Menu");
    }
}
