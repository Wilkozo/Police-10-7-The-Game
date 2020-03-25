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
        if (other.tag == "Player" && MissionMan.missionStarted == false) {
            MissionMan.MissionSuccess.SetActive(false);
            MissionMan.MissionFailure.SetActive(false);
            MissionMan.MissionStart.SetActive(true);
            if (Input.GetButtonDown("Interact"))
            {
                //delivery mission start
                if (MissionMan.missionTypeString == "Delivery")
                {
                    MissionMan.MissionStart.SetActive(false);
                    MissionMan.startDeliveryMission();
                }
                //car chase mission start
                if (MissionMan.missionTypeString == "CarChase")
                {
                    MissionMan.MissionStart.SetActive(false);
                    MissionMan.startCarChaseMission();
                }
                //tail a car mission start
                if (MissionMan.missionTypeString == "Tail a Car")
                {
                    MissionMan.MissionStart.SetActive(false);
                    MissionMan.startTailingMission();
                }
            }
        }
    }


}
