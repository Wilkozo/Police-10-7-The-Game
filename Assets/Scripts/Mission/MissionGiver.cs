using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionGiver : MonoBehaviour
{
    //reference to the mission manager
    public MissionManager MissionMan;

    private void Start()
    {
        //get the mission manager
        MissionMan = this.transform.parent.GetComponent<MissionManager>();
    }

    //when the player stays in the trigger zone
    private void OnTriggerStay(Collider other)
    {
        //how to start a mission, player pushes interact and is within the trigger box
        if (other.tag == "Player" && Input.GetButtonDown("Interact") && MissionMan.missionStarted == false) {

            //delivery mission start
            if (MissionMan.missionTypeString == "Delivery") {
                MissionMan.startDeliveryMission();
            }
            //car chase mission start
            if (MissionMan.missionTypeString == "CarChase")
            {
                MissionMan.startCarChaseMission();
            }
            //tail a car mission start
            if (MissionMan.missionTypeString == "Tail a Car")
            {
                MissionMan.startTailingMission();
            }
        }
    }


}
