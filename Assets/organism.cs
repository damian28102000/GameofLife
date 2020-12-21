using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class organism : MonoBehaviour
{
    public bool isAlive = false;

    void Update()
    {
        if(isAlive)
        {
            GetComponent<Renderer>().material.color = new Color(0, 255, 0);
        }
        else
        {
            GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        }
    }
}
