using System.Collections;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;


//used as a base class for ai to wander
public class BasicWander : MonoBehaviour
{
    //public Transform[] points;
    public List<Transform> points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public float timer;

    public Transform pathToFollow;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = true;


        foreach (Transform child in pathToFollow)
        {
            points.Add(child.gameObject.transform);
        }

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
}
