using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Controller : MonoBehaviour
{
    public Text hpText;
    public Text scoreText;

    public Button pauseButton;
    public GameObject pausePanel;
    public GameObject winPanel;
    public GameObject pickUpEffect;

    private int pickupMax = 12;
    public static int level2Point = 0;
    public void Update()
    {
        hpText.text = GameManager.lifes.ToString();
        scoreText.text = level2Point.ToString();
        CountPickUp();
    }

    public void CountPickUp()
    {
        if (level2Point == pickupMax)
        {
            winPanel.SetActive(true);
        }
        if (winPanel.activeSelf)
        {
            Time.timeScale = 0f;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            GameObject effect = (GameObject)Instantiate(pickUpEffect, other.transform.position, other.transform.rotation);
            Destroy(effect, 3);
            other.gameObject.SetActive(false); // Or Destroy(info.gameObject);
            GameManager.currentScore += 1;
            level2Point += 1;
        }
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("Level_2");
    }
    public void BackLevel()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("Menu");
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
    public void BackButton()
    {
        Application.LoadLevel("Level_1");
    }
}
