using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StealACar : MonoBehaviour
{

    //the car that should be stolen
    public GameObject carToSteal;
    public Text objectiveText;

    private void Start()
    {
        objectiveText.enabled = false;
    }


    //what to do when a trying to start the mission
    public void enableMission() {
        //checks to see if the player is already in a mission
        if (MissionManager.missionStart == false)
        {
            //set it so there is a mission
            MissionManager.missionStart = true;
            //set the mission text
            objectiveText.enabled = true;
        }
        //if they are then return
        else {
            return;
        }
    }

    //trigger collider
    private void OnTriggerEnter(Collider other)
    {
        //if the player collides with the building they are taking the car to
        if (other.gameObject == carToSteal) {
            //complete the mission
            MissionManager.missionEndSuccess();
            objectiveText.enabled = false;
            //complete the mission
            //otherwise dont do anything
        }
    }
}
