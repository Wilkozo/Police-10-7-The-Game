using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailingDistance : MonoBehaviour
{
    //variables for the player and mission manager
    public GameObject Player;
    public MissionManager manager;

    private void Start()
    {
        //finding the player
        Player = GameObject.FindGameObjectWithTag("Player");
        //finding the mission manager script
        manager = this.GetComponentInParent<MissionManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (manager.missionStarted)
        {
            //get the distance from the tailing car and the player
            float distanceFromTail = Vector3.Distance(this.transform.position, Player.transform.position);

            //if the player is too close or too far fail the mission
            if (distanceFromTail > manager.maxDistanceTailing || distanceFromTail < manager.minDistance)
            {
                //false for failure
                manager.endTailingMission(false);
            }
        }
        //the success for this mission is kept in the WaypointNavigator Script
    }
}
