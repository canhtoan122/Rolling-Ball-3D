using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closegame : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "web")
        {
            Application.LoadLevel("Summary");
        }
    }
}
