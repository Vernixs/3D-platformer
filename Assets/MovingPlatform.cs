using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    
    public Transform myPlatForm;
    public Transform myStartPoint;
    public Transform myEndPoint;

    public float speed = 0.01f;
    bool isReversing = false;

    void Start()
    {
        myPlatForm.position = myStartPoint.position;
    }


    void Update()
    {
        if (isReversing == false)
        {
            myPlatForm.position = Vector3.MoveTowards(myPlatForm.position, myEndPoint.position, speed);

            if (myPlatForm.position == myEndPoint.position)
            {
                isReversing = true;
            }
        }
        else
        {
            myPlatForm.position = Vector3.MoveTowards(myPlatForm.position, myStartPoint.position, speed);

            if (myPlatForm.position == myStartPoint.position)
            {
                isReversing = false;
            }
        }
    }
}
