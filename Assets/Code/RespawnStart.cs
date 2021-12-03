using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnStart : MonoBehaviour
{
    public GameObject player;
    public Transform SpawnPoint;

    private void OnTriggerEnter(Collider col) {
        if (col.tag == "Player")
        {
            player.transform.position = SpawnPoint.transform.position;
        }

    }
}
