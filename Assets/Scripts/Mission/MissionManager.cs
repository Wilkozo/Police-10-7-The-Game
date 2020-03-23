using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


//this is a manager class in which holds what to do when a mission starts and when it ends
public class MissionManager : MonoBehaviour
{

    [Header("Know What Mission Type it is")]
    public string missionTypeString;
    

    [Header("Used in Delivery mission")]
    public GameObject endPos;
    public float timeToReachEndPos;


    [Header("Used in Car Chase mission")]
    public GameObject carToChase;
    public float maxDistanceChase;


    [Header("Used in tailing mission")]
    public GameObject carToTail;
    public float maxDistanceTailing;
    public float minDistance;

    //Called Every Frame
    private void Update(){
        
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


    //what to do when a delivery mission starts
    public void startDeliveryMission() {

    }

    //How and what to do when the delivery mission ends
    public void endDeliveryMission(){

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
