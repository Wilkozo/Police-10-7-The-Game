using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

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

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rotation.y = transform.eulerAngles.y;
        drivingCam.enabled = false;
    }

    void Update()
    {

        if (Input.GetButtonDown("ExitCar"))
        {
            //add code so the player can leave and enter cars
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            this.gameObject.GetComponent<CharacterController>().enabled = true;
            this.transform.parent.GetComponent<WheelDrive>().PlayerDrivable = false;
            this.transform.parent = null;

            drivingCam.enabled = false;
            mainCam.enabled = true;
        }

        //various movement settings
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
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
            other.gameObject.GetComponent<WheelDrive>().PlayerDrivable = true;
            //disable walking controls
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<CharacterController>().enabled = false;
            //change the cameras
            drivingCam.enabled = true;
            mainCam.enabled = false;
            //set the target for the driving camera
            camControl.enterCar(other.gameObject.transform.Find("CamLookAtTarget"), other.gameObject.transform.Find("CamPosition"), other.gameObject.transform.Find("CamSidePosition"));
            //set the player to a child of the car
            this.transform.parent = other.gameObject.transform;
   
          }
        
    }

    private void OnTriggerEnter(Collider other)
    {
      
    }

    //when the player leaves the climbable zone
    private void OnTriggerExit(Collider other)
    {
    }
}
