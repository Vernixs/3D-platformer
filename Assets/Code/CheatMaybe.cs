using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatMaybe : MonoBehaviour
{

    public GameObject player;
    public Transform spawnPoint;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.transform.position = spawnPoint.transform.position;
        }
    }

}
 