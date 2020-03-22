using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


//this is a manager class in which holds what to do when a mission starts and when it ends
public class MissionManager : MonoBehaviour
{

    public static GameObject missionComplete;
    private static bool missionStarted;

    private void Start()
    {
        missionComplete = GameObject.Find("MissionComplete");
        missionComplete.SetActive(false);
    }

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

    public static GameObject missionCompleteText
    {
        get
        {
            return missionComplete;
        }
        set
        {
            missionComplete = value;
        }
    }

    //call this when a mission ends in success
    static public void missionEndSuccess() {
        //add dialogue saying that you completed the mission
        missionStarted = false;
        missionComplete.SetActive(true);
    }


    //call this when a mission ends in a failure
    static public void missionEndFailure() {
        missionComplete.SetActive(true);
    }


}
