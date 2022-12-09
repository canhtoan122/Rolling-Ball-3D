using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using UnityEngine;

public class MarketController : MonoBehaviour
{
    private string connectionString;
    SqlConnection connection;
    SqlCommand cmd;

    private int newRuby;

    public void Gem100()
    {
        string oldRuby = DisplayScreenController.ruby;
        newRuby = Convert.ToInt32(oldRuby);
        newRuby += 100;
        Buy();
        Application.LoadLevel("display screen");
    }
    public void Gem220()
    {
        string oldRuby = DisplayScreenController.ruby;
        newRuby = Convert.ToInt32(oldRuby);
        newRuby += 220;
        Buy();
        Application.LoadLevel("display screen");
    }
    public void Gem360()
    {
        string oldRuby = DisplayScreenController.ruby;
        newRuby = Convert.ToInt32(oldRuby);
        newRuby += 360;
        Buy();
        Application.LoadLevel("display screen");
    }
    public void Buy()
    {
        newRuby.ToString();
        connectionString = @"Data Source=ADMIN-PC;Initial Catalog=Account;Integrated Security=True";
        connection = new SqlConnection(connectionString);


        string newUsername = LoginPageController.username;
        String updateRuby = "UPDATE ruby SET Ruby = '" + newRuby + "' WHERE Username = ('" + newUsername + "');";
        cmd = new SqlCommand(updateRuby, connection);
        connection.Open();
        cmd.ExecuteNonQuery();
        connection.Close();
    }

    public void BackButton()
    {
        Application.LoadLevel("display screen");
    }

    
}
