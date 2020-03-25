using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    // Movement Speed
    public float speed = 7.5f;
    public Transform playerCameraParent;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    public bool canMove = true;
    [SerializeField] WheelDrive drive;
    [SerializeField] DriftCamera camControl;

    public bool isActive = true;
    public Camera mainCam;
    public Camera drivingCam;

    Vector3 MousePos;

    public float gravity = 10;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rotation.y = transform.eulerAngles.y;
    }

    void Update()
    {

        if (Input.GetButtonDown("ExitCar"))
        {
            //add code so the player can leave and enter cars
            this.gameObject.GetComponent<CharacterController>().enabled = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
            this.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
            this.transform.parent.GetComponentInChildren<WheelDrive>().PlayerDrivable = false;

            this.transform.parent.GetComponent<WheelDrive>().maxTorque = 300.0f;
            this.transform.parent = null;
        }

        //various movement settings
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // X & Y Movement Variables
        float curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;

        // Applying X & Y to one direction...
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Mouse Position... (Twinstick will come up later)
        MousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);


        if (canMove)
        {
            // Vector3 lookDirection = MousePos - this.gameObject.transform.position;
            // float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

            //this.gameObject.transform.localRotation = Quaternion.Euler(lookDirection.x, 0, 0);
            // transform.eulerAngles = new Vector2(0, angle);


            // Player and Camera rotation
            rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
            this.gameObject.transform.localRotation = Quaternion.Euler(rotation.x, 0, 0);
            transform.eulerAngles = new Vector2(0, rotation.y);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (Input.GetButtonDown("EnterCar") && other.tag == "Car")
        {
            //sets which car can be driven
            other.gameObject.GetComponentInChildren<WheelDrive>().PlayerDrivable = true;
            //disable walking controls
            this.gameObject.GetComponent<CharacterController>().enabled = false;
            this.transform.parent = other.gameObject.transform;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            if (other.gameObject.GetComponent<NavMeshAgent>())
            {
                other.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                other.gameObject.GetComponent<WaypointNavigator>().enabled = false;
                this.transform.parent = other.gameObject.transform;
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (Input.GetButtonDown("EnterCar") && other.tag == "Car")
        {
            //sets which car can be driven
            other.gameObject.GetComponent<WheelDrive>().PlayerDrivable = true;
            //disable walking controls
            this.gameObject.GetComponent<CharacterController>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.transform.parent = other.gameObject.transform;
            this.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            if (other.gameObject.GetComponent<NavMeshAgent>())
            {
                other.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                other.gameObject.GetComponent<WaypointNavigator>().enabled = false;
                this.transform.parent = other.gameObject.transform;
            }
            //this.transform.parent = other.gameObject.transform.Find("Car");

        }
    }


    //when the player leaves the climbable zone
    //   private void OnTriggerExit(Collider other)
    //   {
    //   }

}