﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


//this is a manager class in which holds what to do when a mission starts and when it ends
public class MissionManager : MonoBehaviour
{
    #region variables

    [Header("Whether a mission has been started or not")]
    public bool missionStarted = false;

    [Header("Know What Mission Type it is")]
    public string missionTypeString;
    

    [Header("Used in Delivery mission")]
    public GameObject endPos;
    public GameObject deliveryTimer;
    public float timeToReachEndPos = 20.0f;
    public float timeToReachEndPosOG;


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
    public GameObject MissionStart;
    public GameObject ObjectiveText;
    public GameObject Player;

    #endregion

    private void Start()
    {
        timeToReachEndPosOG = timeToReachEndPos;

        //find the text and images
        Player = GameObject.FindGameObjectWithTag("Player");
        MissionSuccess = GameObject.Find("MissionSuccess");
        MissionFailure = GameObject.Find("MissionFailure");
        MissionStart = GameObject.Find("MissionStart");
        deliveryTimer = GameObject.Find("DeliveryTimer");
        ObjectiveText = GameObject.Find("ObjectiveText");
       
        //set UI elements to false
        //carToChaseImage.SetActive(false);
        //carToTailImage.SetActive(false);
        deliveryTimer.SetActive(false);
        MissionSuccess.SetActive(false);
        MissionFailure.SetActive(false);
        MissionStart.SetActive(false);
        ObjectiveText.SetActive(false);

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

        //Delivery Mission
        //reduce the timer if the UI element is enabled
        if (deliveryTimer.activeInHierarchy) {
            //set the time remaining to 0 decimal places
            deliveryTimer.GetComponent<Text>().text = "Time Remaining: " + timeToReachEndPos.ToString("F0");
            //reduce the time remaining
            timeToReachEndPos -= Time.deltaTime;
            //if the time = 0 then set the time to 0 and fail the mission
            if (timeToReachEndPos <= 0) {
                timeToReachEndPos = 0;
                endDeliveryMission();
            }
        }


        //Tailing Mission
        if (missionTypeString == "Tail a Car") {
            //get the distance from the tailing car and the player
            float distanceFromTail = Vector3.Distance(carToChase.transform.position, Player.transform.position);
            
            //if the player is too close or too far fail the mission
            if (distanceFromTail > maxDistanceTailing || distanceFromTail < minDistance) {
                //false for failure
                endTailingMission(false);
            }
            //the success for this mission is kept in the WaypointNavigator Script
        }
    }

    #region DeliveryMission

    //what to do when a delivery mission starts
    public void startDeliveryMission() {
        //set it so the mission has been started
        missionStarted = true;
        //activate the delivery timer
        deliveryTimer.SetActive(true);
        ObjectiveText.SetActive(true);
        MissionStart.SetActive(false);

        ObjectiveText.GetComponent<Text>().text = "Deliver The Package";
    }

    //How and what to do when the delivery mission ends
    public void endDeliveryMission(){
        //if the timer ran out 
        if (timeToReachEndPos <= 0)
        {
            MissionFailure.SetActive(true);
            ObjectiveText.SetActive(false);
            //reset the timer
            timeToReachEndPos = timeToReachEndPosOG;
        }
        //if the player got to the position in time
        else {
            MissionSuccess.SetActive(true);
            ObjectiveText.SetActive(false);
            //destroy the mission object when the mission is complete
            Destroy(this.gameObject);
        }
        //set it so there is no mission and there is no timer
        missionStarted = false;
        deliveryTimer.SetActive(false);
    }

    #endregion

    //what to do when a tailing mission starts
    public void startTailingMission()
    {
        //set it so there is a mission
        missionStarted = true;
        //change the objective text
        ObjectiveText.GetComponent<Text>().text = "Tail the car, just don't get too close";
        //set the image of the car that should be tailed
        carToTailImage.SetActive(true);

    }

    //How and what to do when the tailing mission ends
    public void endTailingMission(bool success)
    {
        //if the player completes the mission
        if (success)
        {
            //set the mission success text to true
            MissionSuccess.SetActive(true);
            //set the objective text to false
            ObjectiveText.SetActive(false);
            //destroy this gameobject
            Destroy(this.gameObject);
        }
        else {
            //set the mission failure text to true
            MissionFailure.SetActive(true);
            //set the objective text to false
            ObjectiveText.SetActive(false);
        }
        //set it so there is no active mission
        missionStarted = false;
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
