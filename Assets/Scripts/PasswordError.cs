using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordError : MonoBehaviour
{
    public GameObject ConfirmPasswordText;
    public double timeValue;
    // Update is called once per frame
    void Update()
    {
        EnableActive();
    }
    public void EnableActive()
    {
        if (ConfirmPasswordText.activeSelf)
        {
            gameObject.SetActive(false);
        }
        if (gameObject.activeSelf)
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
