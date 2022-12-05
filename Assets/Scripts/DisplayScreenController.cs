using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScreenController : MonoBehaviour
{
    public Skin skin;
    public GameObject player;
    public Material skin1;
    public Material skin2;
    public Material skin3;
    public Material skin4;
    public void Skin1()
    {
        skin.material  = skin1;
        Renderer renderer = player.GetComponent<Renderer>();
        renderer.material = skin.material;
    }
    public void Skin2()
    {
        skin.material = skin2;
        Renderer renderer = player.GetComponent<Renderer>();
        renderer.material = skin.material;
    }
    public void Skin3()
    {
        skin.material = skin3;
        Renderer renderer = player.GetComponent<Renderer>();
        renderer.material = skin.material;
    }
    public void Skin4()
    {
        skin.material = skin4;
        Renderer renderer = player.GetComponent<Renderer>();
        renderer.material = skin.material;
    }
    public void QuitButton()
    {
        Application.LoadLevel("Account");
    }
    public Button skinButton;
    public Button rocketButton;
    public Button treeButton;
    public Button lightButton;
    public Button skin1Button;
    public Button skin2Button;
    public Button skin3Button;
    public Button skin4Button;
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
        skin2Button.gameObject.SetActive(true);
        skin3Button.gameObject.SetActive(true);
        skin4Button.gameObject.SetActive(true);
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
}

