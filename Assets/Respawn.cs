using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public RespawnLast rl;

    public GameObject player;

    private void Start()
    {
        rl = GameObject.Find("floor").GetComponent<RespawnLast>();
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            player.transform.position = rl.lastPosition;
        }
    }
}
