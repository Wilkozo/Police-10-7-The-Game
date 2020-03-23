using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


//this is a manager class in which holds what to do when a mission starts and when it ends
public class MissionManager : MonoBehaviour
{

    [Header("Whether a mission has been started or not")]
    public bool missionStarted = false;

    [Header("Know What Mission Type it is")]
    public string missionTypeString;
    

    [Header("Used in Delivery mission")]
    public GameObject endPos;
    public GameObject deliveryTimer;
    public float timeToReachEndPos;


    [Header("Used in Car Chase mission")]
    public GameObject carToChase;
    public GameObject carToChaseImage;
    public float maxDistanceChase;


    [Header("Used in tailing mission")]
    public GameObject carToTail;
    public GameObject carToTailImage;
    public float maxDistanceTailing;
    public float minDistance;

    [Header("Used for all")]
    public GameObject MissionSuccess;
    public GameObject MissionFailure;


    private void Start()
    {
        //find the text and images
        MissionSuccess = GameObject.Find("MissionSuccess");
        MissionFailure = GameObject.Find("MissionFailure");
        //set UI elements to false
        carToChaseImage.SetActive(false);
        carToTailImage.SetActive(false);
        deliveryTimer.SetActive(false);
        MissionSuccess.SetActive(false);
        MissionFailure.SetActive(false);

    }
    //what is the mission type
    public void missionType(string mission) {

        //If the mission is a tailing type
        if (mission == "Tail a Car") {
            missionTypeString = "Tail a Car";
        }
        //if the mission is a delivery type
        if (mission == "Delivery") {
            //set the string to be a delivery mission
            missionTypeString = "Delivery";
        }
        //if the mission is a car chase type
        if (mission == "CarChase"){
            //set the string to car chase mission
            missionTypeString = "CarChase";
        }
        //what to do in a custom mission
        if (mission == "Custom") {
            //set the string to custom mission
            missionTypeString = "Custom";
        }
    }

    private void Update()
    {
        //reduce the timer if the UI element is enabled
        if (deliveryTimer.activeInHierarchy) {
            timeToReachEndPos -= Time.deltaTime;
            if (timeToReachEndPos <= 0) {
                timeToReachEndPos = 0;
                endDeliveryMission();
            }
        }
    }

    //what to do when a delivery mission starts
    public void startDeliveryMission() {
        //set it so the mission has been started
        missionStarted = true;
        //activate the delivery timer
        deliveryTimer.SetActive(true);
    }

    //How and what to do when the delivery mission ends
    public void endDeliveryMission(){
        //if the timer ran out 
        if (timeToReachEndPos <= 0)
        {
            MissionFailure.SetActive(true);
        }
        //if the player got to the position in time
        else {
            MissionSuccess.SetActive(true);
        }
        //set it so there is no mission and there is no timer
        missionStarted = false;
        deliveryTimer.SetActive(false);
    }


    //what to do when a tailing mission starts
    public void startTailingMission()
    {

    }

    //How and what to do when the tailing mission ends
    public void endTailingMission()
    {

    }


    //what to do when a car chase mission starts
    public void startCarChaseMission()
    {

    }

    //How and what to do when the car chase mission ends
    public void endCarChaseMission()
    {

    }
}
