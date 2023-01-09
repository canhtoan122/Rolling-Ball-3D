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
    public Text errorNull;
    public Text errorUsername;
    public Text errorPassword;
    public Text confirmPassword;

    public static string username;
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
        if (username == "" || password == "" || confirmPasswordStr == "")
        {
            errorNull.gameObject.SetActive(true);
        }
        else
        {
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
                String checkPasswordStr = "select Password from AccountInfo where Password = '" + password + "';";
                cmd = new SqlCommand(checkPasswordStr, connection);
                SqlDataAdapter adapterPass = new SqlDataAdapter(cmd);
                DataTable dtPass = new DataTable();
                adapterPass.Fill(dtPass);
                if (dtPass.Rows.Count > 0)
                {
                    errorPassword.gameObject.SetActive(true);
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
        }
    }
    public void AddRuby()
    {
        String rubyStr = "INSERT INTO ruby(Username, Ruby) VALUES ('" + username + "', 0)";
        cmd = new SqlCommand(rubyStr, connection);
        try
        {
            connection.Open();
            cmd.ExecuteNonQuery();

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
    public void CreateAccountButton()
    {
        AddAccount();
        AddRuby();
    }
    public void BackButton()
    {
        Application.LoadLevel("Account");
    }
}
