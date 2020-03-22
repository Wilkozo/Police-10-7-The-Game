using System.Collections;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;


//used to detect audio and visual sources
public class Detect : MonoBehaviour
{
    public bool Played = false;

    private NavMeshAgent agent;

    //how fast the ai will travel
    public float speed;

    //how far the ai can see
    public float viewLength;

    private void Start()
    {
        //get the navemesh agent component of the ai
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        //raycast hiting object
        RaycastHit objectHit;
    
        //get the forward vector3
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z), fwd * viewLength, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - 0.75f, transform.position.z), fwd * viewLength, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z), fwd * viewLength, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.75f, transform.position.z), fwd * viewLength, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1.25f, transform.position.z), fwd * viewLength, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1.75f, transform.position.z), fwd * viewLength, Color.green);


        //if it hits something then stop
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), fwd, out objectHit, viewLength))
        {
             agent.speed = 0;
            agent.velocity = Vector3.zero;
        }
        else {
            agent.speed = 8;
        }
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1.25f, transform.position.z), fwd, out objectHit, viewLength))
        {
            agent.speed = 0;
            agent.velocity = Vector3.zero;
        }
        else
        {
            agent.speed = 8;
        }
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.75f, transform.position.z), fwd, out objectHit, viewLength))
        {
            agent.speed = 0;
            agent.velocity = Vector3.zero;
        }
        else
        {
            agent.speed = 8;
        }
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1.75f, transform.position.z), fwd, out objectHit, viewLength))
        {
            agent.speed = 0;
            agent.velocity = Vector3.zero;
        }
        else
        {
            agent.speed = 8;
        }
    }
}
