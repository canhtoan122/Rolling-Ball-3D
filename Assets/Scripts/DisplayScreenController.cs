using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScreenController : MonoBehaviour
{
    public Skin skin;
    public GameObject player;
    public Material defaultSkin;
    public Material skin1;
    public Material skin2;
    public Material skin3;
    public Material skin4;

    private bool isCheckSkin1 = true;
    private bool isCheckSkin2 = true;
    private bool isCheckSkin3 = true;
    private bool isCheckSkin4 = true;
    public void Skin1()
    {
        if(isCheckSkin1 == true)
        {
            skin.material = skin1;
            Renderer renderer = player.GetComponent<Renderer>();
            renderer.material = skin.material;
            isCheckSkin1 = false;
        }
        else
        {
            skin.material = defaultSkin;
            Renderer renderer = player.GetComponent<Renderer>();
            renderer.material = skin.material;
            isCheckSkin1 = true;
        }
    }
    public void Skin2()
    {
        if (isCheckSkin2 == true)
        {
            skin.material = skin2;
            Renderer renderer = player.GetComponent<Renderer>();
            renderer.material = skin.material;
            isCheckSkin2 = false;
        }
        else
        {
            skin.material = defaultSkin;
            Renderer renderer = player.GetComponent<Renderer>();
            renderer.material = skin.material;
            isCheckSkin2 = true;
        }
    }
    public void Skin3()
    {
        if (isCheckSkin3 == true)
        {
            skin.material = skin3;
            Renderer renderer = player.GetComponent<Renderer>();
            renderer.material = skin.material;
            isCheckSkin3 = false;
        }
        else
        {
            skin.material = defaultSkin;
            Renderer renderer = player.GetComponent<Renderer>();
            renderer.material = skin.material;
            isCheckSkin3 = true;
        }
    }
    public void Skin4()
    {
        if (isCheckSkin4 == true)
        {
            skin.material = skin4;
            Renderer renderer = player.GetComponent<Renderer>();
            renderer.material = skin.material;
            isCheckSkin4 = false;
        }
        else
        {
            skin.material = defaultSkin;
            Renderer renderer = player.GetComponent<Renderer>();
            renderer.material = skin.material;
            isCheckSkin4 = true;
        }
    }
    public void QuitButton()
    {
        Application.LoadLevel("Menu");
    }
    public Text rubyText;
    public static string ruby;
    public void Start()
    {
        SaveDatabase();
    }

    private string connectionString;
    SqlConnection connection;
    SqlCommand cmd;
    //SqlDataReader reader;

    public void SaveDatabase()
    {

        connectionString = @"Data Source=ADMIN-PC;Initial Catalog=Account;Integrated Security=True";
        connection = new SqlConnection(connectionString);

        string newUsername = LoginPageController.username;
        String checkRubyStr = "select * from ruby WHERE Username = ('" + newUsername + "');";
        cmd = new SqlCommand(checkRubyStr, connection);
        connection.Open();
        cmd.ExecuteNonQuery();

        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                ruby = Convert.ToString(reader["Ruby"]);
            }
        }
        connection.Close();
        rubyText.text = ruby;
        if(newUsername == null || ruby == "" || ruby == null)
        {
            int defaultRuby = 0;
            rubyText.text = defaultRuby.ToString();
        }
    }
    public GameObject UnlockSkin2Panel;
    public GameObject UnlockSkin3Panel;
    public GameObject UnlockSkin4Panel;
    public GameObject NotEnoughMoneyPanel;
    public void UnlockSkin2()
    {
        UnlockSkin2Panel.SetActive(true);
    }
    public void UnlockSkin3()
    {
        UnlockSkin3Panel.SetActive(true);
    }
    public void UnlockSkin4()
    {
        UnlockSkin4Panel.SetActive(true);
    }
    public void UnlockSkinNoButton()
    {
        UnlockSkin2Panel.SetActive(false);
        UnlockSkin3Panel.SetActive(false);
        UnlockSkin4Panel.SetActive(false);
    }
    public void UnlockSkin2YesButton()
    {
        if(ruby == null)
        {
            UnlockSkin2Panel.SetActive(false);
            NotEnoughMoneyPanel.SetActive(true);
        }
        else
        {
            int checkRuby = int.Parse(ruby);
            if (checkRuby < 100)
            {
                UnlockSkin2Panel.SetActive(false);
                NotEnoughMoneyPanel.SetActive(true);
            }
            else
            {
                checkRuby -= 100;
                checkRuby.ToString();
                connectionString = @"Data Source=ADMIN-PC;Initial Catalog=Account;Integrated Security=True";
                connection = new SqlConnection(connectionString);

                string newUsername = LoginPageController.username;
                String updateRuby = "UPDATE ruby SET Ruby = '" + checkRuby + "', Skin2Status = 1 WHERE Username = ('" + newUsername + "');";
                cmd = new SqlCommand(updateRuby, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                rubyText.text = checkRuby.ToString();
                connection.Close();
                UnlockSkin2Panel.SetActive(false);
                skin2Button.gameObject.SetActive(true);
                ruby = checkRuby.ToString();
            }
        }
    }
    
    public void UnlockSkin3YesButton()
    {
        if (ruby == null)
        {
            UnlockSkin3Panel.SetActive(false);
            NotEnoughMoneyPanel.SetActive(true);
        }
        else
        {
            int checkRuby = int.Parse(ruby);
            if (checkRuby < 220)
            {
                UnlockSkin3Panel.SetActive(false);
                NotEnoughMoneyPanel.SetActive(true);
            }
            else
            {
                checkRuby -= 220;
                checkRuby.ToString();
                connectionString = @"Data Source=ADMIN-PC;Initial Catalog=Account;Integrated Security=True";
                connection = new SqlConnection(connectionString);

                string newUsername = LoginPageController.username;
                String updateRuby = "UPDATE ruby SET Ruby = '" + checkRuby + "', Skin3Status = 1 WHERE Username = ('" + newUsername + "');";
                cmd = new SqlCommand(updateRuby, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                rubyText.text = checkRuby.ToString();
                connection.Close();
                UnlockSkin3Panel.SetActive(false);
                skin3Button.gameObject.SetActive(true);
                ruby = checkRuby.ToString();
            }
        }
    }
    public void UnlockSkin4YesButton()
    {
        if (ruby == null)
        {
            UnlockSkin4Panel.SetActive(false);
            NotEnoughMoneyPanel.SetActive(true);
        }
        else
        {
            int checkRuby = int.Parse(ruby);
            if (checkRuby < 360)
            {
                UnlockSkin4Panel.SetActive(false);
                NotEnoughMoneyPanel.SetActive(true);
            }
            else
            {
                checkRuby -= 360;
                checkRuby.ToString();
                connectionString = @"Data Source=ADMIN-PC;Initial Catalog=Account;Integrated Security=True";
                connection = new SqlConnection(connectionString);

                string newUsername = LoginPageController.username;
                String updateRuby = "UPDATE ruby SET Ruby = '" + checkRuby + "', Skin4Status = 1 WHERE Username = ('" + newUsername + "');";
                cmd = new SqlCommand(updateRuby, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                rubyText.text = checkRuby.ToString();
                connection.Close();
                UnlockSkin4Panel.SetActive(false);
                skin4Button.gameObject.SetActive(true);
                ruby = checkRuby.ToString();
            }
        }
    }
    public Button skin2Button;
    public Button skin3Button;
    public Button skin4Button;
    public void ActiveSkin2()
    {
        connectionString = @"Data Source=ADMIN-PC;Initial Catalog=Account;Integrated Security=True";
        connection = new SqlConnection(connectionString);

        string newUsername = LoginPageController.username;
        String checkSkin = "select Skin2Status from ruby where Username = ('" + newUsername + "');";
        cmd = new SqlCommand(checkSkin, connection);
        connection.Open();
        cmd.ExecuteNonQuery();
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                string checkSkinStatus = Convert.ToString(reader["Skin2Status"]);
                if (checkSkinStatus == "True")
                {
                    skin2LockButton.gameObject.SetActive(false);
                    skin2Button.gameObject.SetActive(true);
                }
                else
                {
                    skin2LockButton.gameObject.SetActive(true);
                }
            }
        }
        connection.Close();
    }
    public void ActiveSkin3()
    {
        connectionString = @"Data Source=ADMIN-PC;Initial Catalog=Account;Integrated Security=True";
        connection = new SqlConnection(connectionString);

        string newUsername = LoginPageController.username;
        String checkSkin = "select Skin3Status from ruby where Username = ('" + newUsername + "');";
        cmd = new SqlCommand(checkSkin, connection);
        connection.Open();
        cmd.ExecuteNonQuery();
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                string checkSkinStatus = Convert.ToString(reader["Skin3Status"]);
                if (checkSkinStatus == "True")
                {
                    skin3LockButton.gameObject.SetActive(false);
                    skin3Button.gameObject.SetActive(true);
                }
                else
                {
                    skin3LockButton.gameObject.SetActive(true);
                }
            }
        }
        connection.Close();
    }
    public void ActiveSkin4()
    {
        connectionString = @"Data Source=ADMIN-PC;Initial Catalog=Account;Integrated Security=True";
        connection = new SqlConnection(connectionString);

        string newUsername = LoginPageController.username;
        String checkSkin = "select Skin4Status from ruby where Username = ('" + newUsername + "');";
        cmd = new SqlCommand(checkSkin, connection);
        connection.Open();
        cmd.ExecuteNonQuery();
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                string checkSkinStatus = Convert.ToString(reader["Skin4Status"]);
                if (checkSkinStatus == "True")
                {
                    skin4LockButton.gameObject.SetActive(false);
                    skin4Button.gameObject.SetActive(true);
                }
                else
                {
                    skin4LockButton.gameObject.SetActive(true);
                }
            }
        }
        connection.Close();
    }
    public void NotEnoughNoButton()
    {
        NotEnoughMoneyPanel.SetActive(false);
    }
    public void NotEnoughYesButton()
    {
        Application.LoadLevel("Market");
    }
    public Button skinButton;
    public Button rocketButton;
    public Button treeButton;
    public Button lightButton;
    public Button skin1Button;
    public Button skin2LockButton;
    public Button skin3LockButton;
    public Button skin4LockButton;
    public GameObject rocket1;
    public GameObject rocket2;
    public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject tree4;
    public GameObject tree5;
    public GameObject tree6;
    public GameObject tree7;
    public GameObject light;
    public void Skin()
    {
        skinButton.gameObject.SetActive(false);
        rocketButton.gameObject.SetActive(false);
        treeButton.gameObject.SetActive(false);
        lightButton.gameObject.SetActive(false);
        skin1Button.gameObject.SetActive(true);
        skin2LockButton.gameObject.SetActive(true);
        if (skin2LockButton.isActiveAndEnabled)
        {
            ActiveSkin2();
        }
        else
        {
            skin2LockButton.gameObject.SetActive(true);
        }
        skin3LockButton.gameObject.SetActive(true);
        if (skin3LockButton.isActiveAndEnabled)
        {
            ActiveSkin3();
        }
        else
        {
            skin3LockButton.gameObject.SetActive(true);
        }
        skin4LockButton.gameObject.SetActive(true);
        if (skin4LockButton.isActiveAndEnabled)
        {
            ActiveSkin4();
        }
        else
        {
            skin4LockButton.gameObject.SetActive(true);
        }
    }
    public void Rocket1()
    {
        rocket1.SetActive(false);
        rocket2.SetActive(false);
    }
    public void Rocket2()
    {
        rocket1.SetActive(true);
        rocket2.SetActive(true);
    }
    int i = 2;
    
    public void Rocket()
    {
        
        
        switch (i++%2)
        {
            case 0:
    
                Rocket1();
                break;
            
            case 1:
                
                Rocket2();
                break;
        }


    }
    int a = 2;
    public void Tree()
    {
        switch (a++ % 2)
        {
            case 0:

                tree1.SetActive(false);
                tree2.SetActive(false);
                tree3.SetActive(false);
                tree4.SetActive(false);
                tree5.SetActive(false);
                tree6.SetActive(false);
                tree7.SetActive(false);
                break;

            case 1:

                tree1.SetActive(true);
                tree2.SetActive(true);
                tree3.SetActive(true);
                tree4.SetActive(true);
                tree5.SetActive(true);
                tree6.SetActive(true);
                tree7.SetActive(true);
                break;
        }
    }
    int b = 2;
    public void Light()
    {
        switch (b++ % 2)
        {
            case 0:

                light.SetActive(false);
                break;

            case 1:

                light.SetActive(true);
                break;
        }
    }
    public void Market()
    {
        Application.LoadLevel("Market");
    }
}

