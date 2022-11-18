using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UnityEngine;
using UnityEngine.UI;

public class CreateNewAccountController : MonoBehaviour
{
    public InputField usernameText;
    public InputField passwordText;
    public InputField confirmPasswordText;
    public Text errorUsername;
    public Text errorPassword;
    public Text confirmPassword;

    private string username;
    private string password;
    private string confirmPasswordStr;

    private string connectionString;
    SqlConnection connection;
    SqlCommand cmd;
    SqlDataReader reader;
    public void AddAccount()
    {
        username = usernameText.text;
        password = passwordText.text;
        confirmPasswordStr = confirmPasswordText.text;
        connectionString = @"Data Source=ADMIN-PC;Initial Catalog=Account;Integrated Security=True";
        connection = new SqlConnection(connectionString);

        String checkUsernameStr = "select Username from AccountInfo where Username = '" + username + "';";
        cmd = new SqlCommand(checkUsernameStr, connection);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            errorUsername.gameObject.SetActive(true);
            connection.Close();
        }
        else
        {
            
            if (password != confirmPasswordStr)
            {
                confirmPassword.gameObject.SetActive(true);
                connection.Close();
            }
            else
            {
                String cmdStr = "INSERT INTO AccountInfo(Username, Password) VALUES ('" + username + "', '" + password + "')";
                cmd = new SqlCommand(cmdStr, connection);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    Debug.Log("Insert Successfully!");
                    Application.LoadLevel("Account");

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
    }
    public void CreateAccountButton()
    {
        AddAccount();
    }
    public void BackButton()
    {
        Application.LoadLevel("Account");
    }
}
