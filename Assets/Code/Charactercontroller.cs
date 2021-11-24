using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactercontroller : MonoBehaviour
{

    //Movement code and jumping
    public float maxSpeed;
    public float normalSpeed = 10.0f;
    public float sprintSpeed = 20.0f;
    public float maxSprint = 5.0f;
    float sprintTimer;
    float rotation = 0.0f;
    float camRotation = 0.0f;
    public float rotationSpeed = 2.0f;

    public float camRotationSpeed = 1.5f;
    GameObject cam;
    Rigidbody myRigidBody;


    //jumping variables

    bool isOnGround;
    public GameObject groundChecker;
    public LayerMask groundLayer;
    public float jumpForce = 300.0f;

    //teleport

    public float teleport = 1.0f;
    public float cooldown = 2.0f;
    float cooldownTimer;
    bool canTeleport = true;

    //animation

    Animator myAnim;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = GameObject.Find("Main Camera");
        myRigidBody = GetComponent<Rigidbody>();
        sprintTimer = maxSprint;
        myAnim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        //moving controller mechanics and sprinting

        Vector3 newVelocity = transform.forward * Input.GetAxis("Vertical") * maxSpeed + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);
        myRigidBody.velocity = new Vector3(newVelocity.x, myRigidBody.velocity.y, newVelocity.z);


        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation - Input.GetAxis("Mouse Y") * camRotationSpeed;
        cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));


        myRigidBody = GetComponent<Rigidbody>();

        if (Input.GetKey(KeyCode.LeftShift))

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

        //Camera
        camRotation = Mathf.Clamp(camRotation, -40.0f, 40.0f);

        //Jump code
        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);

        //jump code stuff

        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);
        

        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            myAnim.SetTrigger("jumped");
            myRigidBody.AddForce(transform.up * jumpForce);
        }

        //Teleport
        if (Input.GetKeyDown(KeyCode.E) && canTeleport == true)
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(transform.position, fwd, 10))
            {
                print("TP blocked");
            }
            else
            {
                canTeleport = false;
                transform.position += transform.forward * teleport;
                print("TP successful");
            }
        }
        else if (canTeleport == false)
        {

            if (cooldownTimer > cooldown )
            {
                canTeleport = true;
                cooldownTimer = 0.0f;
               
            }
            else
            {
                cooldownTimer += Time.deltaTime;
            }
        }

        //animation
        myAnim.SetFloat("speed", newVelocity.magnitude);
        myAnim.SetBool("isOnGround", isOnGround);
        

    }
}
