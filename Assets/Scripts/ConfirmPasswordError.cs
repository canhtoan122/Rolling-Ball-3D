using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmPasswordError : MonoBehaviour
{
    public double timeValue;
    // Update is called once per frame
    void Update()
    {
        EnableActive();
    }
    public void EnableActive()
    {
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
