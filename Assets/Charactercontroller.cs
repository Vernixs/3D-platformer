using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactercontroller : MonoBehaviour
{
    //moving variables
    public float maxSpeed;
    public float normalSpeed = 10.0f;
    public float sprintSpeed = 20.0f;
    public float maxSprint = 5.0f;
    float sprintTimer;
    float rotation = 0.0f;
    float camRotation = 0.0f;
    public float rotationSpeed = 2.0f;
    public float camRotationSpeed = 3.00f;
    GameObject cam;
    Rigidbody myRigidBody;

    //jumping variables
    bool isOnGround;
    public GameObject groundChecker;
    public LayerMask groundLayer;
    public float jumpForce = 300.0f;

    //Stamina bar
    public float Stamina = 100.0f;
    public float MaxStamina = 100.0f;



    void Start()
    {
        cam = GameObject.Find("Main Camera");
        myRigidBody = GetComponent<Rigidbody>();
        sprintTimer = maxSprint;
    }

    void Update()
    {
        //moving controller mechanics and sprinting

        Vector3 newVelocity = transform.forward * Input.GetAxis("Vertical") * maxSpeed + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);
        myRigidBody.velocity = new Vector3(newVelocity.x, myRigidBody.velocity.y, newVelocity.z);
        //Vector3 newVelocity1 = transform.right * Input.GetAxis("Horizontal") * maxSpeed;
        //myRigidBody.velocity = new Vector3(newVelocity1.x, myRigidBody.velocity.y, newVelocity1.z);

        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation - Input.GetAxis("Mouse Y") * camRotationSpeed;
        cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));

        if (Input.GetKey(KeyCode.LeftShift) && sprintTimer > 0.0f)
        {
            maxSpeed = sprintSpeed;
            sprintTimer = sprintTimer - Time.deltaTime;
        }
        else
        {
            maxSpeed = normalSpeed;
            if (Input.GetKey(KeyCode.LeftShift) == false)
            {
                sprintTimer = sprintTimer + Time.deltaTime;
            }
        }

        sprintTimer = Mathf.Clamp(sprintTimer, 0.0f, maxSprint);

        //jump code stuff

        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);
        
        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.AddForce(transform.up * jumpForce);
        }

        Debug.Log(camRotation);

    }
}
