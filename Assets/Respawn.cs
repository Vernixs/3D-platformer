using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{


    public GameObject Player;
    public Transform SpawnPoint;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Player.transform.position = SpawnPoint.transform.position;
        }
    }
}
