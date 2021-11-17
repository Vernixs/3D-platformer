using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.Log("creating I: " + i);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
