using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDrive : MonoBehaviour
{
    //the car that should be stolen
    public GameObject PlaceToGetTo;
    public Text objectiveText;
    public Text StartMissionText;

    private void Start()
    {
        objectiveText.enabled = false;
        StartMissionText.enabled = false;
    }

    //what to do when a trying to start the mission
    public void enableMission()
    {
        //checks to see if the player is already in a mission
        if (MissionManager.missionStart == false)
        {
            StartMissionText.enabled = false;
            //set it so there is a mission
            MissionManager.missionStart = true;
            //set the mission text
            objectiveText.enabled = true;
        }
        //if they are then return
        else
        {
            return;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButtonDown("Interact"))
        {
            enableMission();
        }
    }

    //trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartMissionText.enabled = false;
        }
        //if the player collides with the building they are taking the car to
        if (objectiveText.enabled == true)
        {
            //complete the mission
            MissionManager.missionEndSuccess();
            objectiveText.enabled = false;
            StartMissionText.enabled = false;
            //complete the mission
            //otherwise dont do anything
        }

    }
    //disable the start mission text
    private void OnTriggerExit(Collider other)
    {
        StartMissionText.enabled = false;
    }
}
