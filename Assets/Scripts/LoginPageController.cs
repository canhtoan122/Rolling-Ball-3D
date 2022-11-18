using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UnityEngine;
using UnityEngine.UI;

public class LoginPageController : MonoBehaviour
{
    public InputField usernameText;
    public InputField passwordText;
    public Text usernameErrorText;
    public Text passwordErrorText;

    private string username;
    private string password;

    private string connectionString;
    SqlConnection connection;
    SqlCommand cmd;
    SqlDataReader reader;

    public void CreateNewAccount()
    {
        Application.LoadLevel("Create Account");
    }
    public void EnterButton()
    {
        username = usernameText.text;
        password = passwordText.text;

        connectionString = @"Data Source=ADMIN-PC;Initial Catalog=Account;Integrated Security=True";
        connection = new SqlConnection(connectionString);


        
        SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) from AccountInfo where Username='" + username + "' AND password='" + password + "'", connection);
        /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
        DataTable dt = new DataTable(); //this is creating a virtual table  
        sda.Fill(dt);
        if (dt.Rows[0][0].ToString() == "1")
        {
            /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */

            Application.LoadLevel("Menu");
        }
        else
        {
            usernameErrorText.gameObject.SetActive(true);
            connection.Close();
        }


        //String checkUsernameStr = "select Username from AccountInfo where Username = '" + username + "';";
        //cmd = new SqlCommand(checkUsernameStr, connection);
        //string id = "select Id from AccountInfo where Username = '" + username + "';";
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //adapter.Fill(dt);
        //if (dt.Rows.Count > 0)
        //{
        //    String checkPasswordStr = "select Password from AccountInfo where Password = '" + password + "';";
        //    cmd = new SqlCommand(checkPasswordStr, connection);
        //    SqlDataAdapter passwordAdapter = new SqlDataAdapter(cmd);
        //    DataTable passwordDt = new DataTable();
        //    passwordAdapter.Fill(passwordDt);
        //    if (passwordDt.Rows.Count > 0)
        //    {
        //        Application.LoadLevel("Menu");
        //    }
        //    else
        //    {
        //        passwordErrorText.gameObject.SetActive(true);
        //        connection.Close();
        //    }
        //}
        //else
        //{
        //    usernameErrorText.gameObject.SetActive(true);
        //    connection.Close();
        //}
    }           
}
