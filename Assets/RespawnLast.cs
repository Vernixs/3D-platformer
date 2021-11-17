using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnLast : MonoBehaviour
{
    Vector3 lastPosition;
 

 

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lastPosition = collision.transform.position;
        }

        if (collision.gameObject.tag == "Death")
        {
            Vector3 newPosition = lastPosition;

        }

    }

    private void Update()
    {

    }
}
