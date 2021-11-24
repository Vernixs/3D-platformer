using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearingPlat: MonoBehaviour
{

    public float cooldown = 2.0f;

    float cooldownTimer;
    float timeVisible = 0.0f;
    public float duration = 3.0f;
    bool isInvisible = true;
    bool touchy = false;


    public void Start()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && (isInvisible = true))
        {
            touchy = true;
        }
    }
    private void Update()
    {

        if (isInvisible == false)
        {
            if (cooldownTimer > cooldown)
            {
                touchy = false;
                isInvisible = true;
                gameObject.SetActive(true);
                cooldownTimer = 0.0f;
            }
            else
            {
                cooldownTimer += Time.deltaTime;
                
            }
        }

        if (touchy == true && (isInvisible == true))
        {
            
            if (timeVisible > duration)
            {
                gameObject.SetActive(false);
                isInvisible = false;
                timeVisible = 0.0f;
            }
            else
            {
                timeVisible += Time.deltaTime;

            }
        }

    }

}
