using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using UnityEngine;
using UnityEngine.UI;

public class SummaryController : MonoBehaviour
{
    public Button playAgainButton;
    public Button Level1Button;
    public Button Level2Button;
    public Text finalScoreText;
    public Text badPickUpsText;
    public Text killedEnemyText;

    private string connectionString;
    SqlConnection connection;
    SqlCommand cmd;
    SqlDataReader reader;

    public void Start()
    {
        finalScoreText.text = GameManager.currentScore.ToString();
        badPickUpsText.text = GameManager.badPickups.ToString();
        killedEnemyText.text = GameManager.killedEnemys.ToString();
        SaveDatabase();
    }
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
    public void SaveDatabase()
    {
        connectionString = @"Data Source=ADMIN-PC;Initial Catalog=Account;Integrated Security=True";
        connection = new SqlConnection(connectionString);

        string newUsername = LoginPageController.username;
        string newPoint = GameManager.currentScore.ToString();
        String cmdStr = "UPDATE AccountInfo SET Point = '" + newPoint + "' WHERE Username = ('" + newUsername + "');";
        cmd = new SqlCommand(cmdStr, connection);
        try
        {
            connection.Open();
            cmd.ExecuteNonQuery();
            Debug.Log("Insert Successfully!");

        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
        finally
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
