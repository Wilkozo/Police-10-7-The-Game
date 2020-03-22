using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class TrafficControl : MonoBehaviour
{
    //public Transform[] points;

    public List<Transform> points;


    private int destPoint = 0;
    private NavMeshAgent agent;
    public float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = true;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Count == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Count;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }

    void clearList()
    {
        for (var i = 0; i < points.Count; i++)
        {
            points.RemoveAt(i);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Path1") {
            clearList();
            foreach (Transform child in other.transform)
            {
                points.Add(child.gameObject.transform);
            }
        }
        if (other.name == "Path2") {
            clearList();
            foreach (Transform child in other.transform)
            {
                points.Add(child.gameObject.transform);
            }
        }
    }
}
