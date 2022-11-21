using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummaryController : MonoBehaviour
{
    public Button playAgainButton;
    public Button Level1Button;
    public Button Level2Button;

    public void LoadPlayAgain()
    {
        playAgainButton.gameObject.SetActive(false);
        Level1Button.gameObject.SetActive(true);
        Level2Button.gameObject.SetActive(true);
    }
    public void LoadLevel1()
    {
        Application.LoadLevel("Level_1");
    }
    public void LoadLevel2()
    {
        Application.LoadLevel("Level_2");
    }
    public void SummaryQuitButton()
    {
        Application.LoadLevel("Account");
    }
}
