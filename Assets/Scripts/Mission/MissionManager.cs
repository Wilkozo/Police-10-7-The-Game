using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this is a manager class in which holds what to do when a mission starts and when it ends
public class MissionManager : MonoBehaviour
{


    private static bool missionStarted;

    public static bool missionStart
    {
        get
        {
            return missionStarted;
        }
        set
        {
            missionStarted = value;
        }
    }

    //call this when a mission ends in success
    static public void missionEndSuccess() {
        //add dialogue saying that you completed the mission
        missionStarted = false;

    }

    //call this when a mission ends in a failure
    static public void missionEndFailure() {
        missionStarted = false;
    }


}
