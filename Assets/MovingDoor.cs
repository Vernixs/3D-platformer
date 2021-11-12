using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDoor : MonoBehaviour
{
    public bool isOpne = false;

    public Transform door;
    public Transform startingPoint;
    public Transform endingPoint;

    private void Start()
    {
        door.position = startingPoint.position;
    }

 
    private void Update()
    {
        if (isOpne == true)
        {
            door.position = Vector3.MoveTowards(door.position, endingPoint.position, Time.deltaTime);
        }

    }
}
