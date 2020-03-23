using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StealACar : MonoBehaviour
{

    //the car that should be stolen
    public GameObject carToSteal;
    public Text objectiveText;
    public Image carToStealImage;
    public Text StartMissionText;

    private void Start()
    {
        objectiveText.enabled = false;
        carToStealImage.enabled = false;
        StartMissionText.enabled = false;
    }


    //what to do when a trying to start the mission
    public void enableMission() {
        //checks to see if the player is already in a mission
        //if (MissionManager.missionStart == false)
        //{
            StartMissionText.enabled = false;
            //set it so there is a mission
            //MissionManager.missionStart = true;
            //set the mission text
            objectiveText.enabled = true;
            carToStealImage.enabled = true;
            this.GetComponent<SphereCollider>().enabled = true;
        //}
        //if they are then return
        //else {
        //    return;
        //}
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButtonDown("Interact"))
        {
            enableMission();
            this.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }

    //trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            StartMissionText.enabled = false;
        }
        //if the player collides with the building they are taking the car to
        if (other.gameObject == carToSteal && objectiveText.enabled == true) {
            //complete the mission
           // MissionManager.missionEndSuccess();
            objectiveText.enabled = false;
            carToStealImage.enabled = false;
            StartMissionText.enabled = false;
            this.GetComponent<SphereCollider>().enabled = false;
            //complete the mission
            //otherwise dont do anything
        }

    }
    private void OnTriggerExit(Collider other)
    {
        StartMissionText.enabled = false;
    }
}
