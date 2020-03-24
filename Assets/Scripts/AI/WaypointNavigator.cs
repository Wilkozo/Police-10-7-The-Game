using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{

    public NavMeshAgent controller;
    public Waypoint currentWaypoint;

    public MissionManager manager;


    private void Awake()
    {
        controller.autoBraking = true;
        controller = GetComponent<NavMeshAgent>();
        controller.destination = currentWaypoint.GetPosition();
        //find the mission manager
        manager = GameObject.Find("MissionManager").GetComponent<MissionManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.remainingDistance < 0.5f) {
            bool shouldBranch = false;
            if (currentWaypoint.branches != null && currentWaypoint.branches.Count > 0) {
                shouldBranch = Random.Range(0f, 1f) <= currentWaypoint.branchRatio ? true : false;
            }
            if (shouldBranch)
            {
                currentWaypoint = currentWaypoint.branches[Random.Range(0, currentWaypoint.branches.Count - 1)];
            }
            else
            {
                currentWaypoint = currentWaypoint.nextWaypoint;
            }
            //if there is no waypoints remaining
            if (currentWaypoint.nextWaypoint == null) {
                //set it so the navmesh agent does not move
                controller.velocity = Vector3.zero;
                //if the car is for a tailing mission set it so the mission is complete
                manager.endTailingMission(true);
            }
            controller.destination = currentWaypoint.GetPosition();
        }
    }
}
