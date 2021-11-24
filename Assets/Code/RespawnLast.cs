using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnLast : MonoBehaviour
{
    public Vector3 lastPosition;
 

 

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lastPosition = collision.transform.position;
        }

    }

}
