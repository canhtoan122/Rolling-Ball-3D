using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closegame : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "web")
        {
            //Level1Controller.level1Point = 0;
            //Level2Controller.level2Point = 0;
            //GameManager.currentScore = 0;

            Application.LoadLevel("Summary");
        }
    }
}
