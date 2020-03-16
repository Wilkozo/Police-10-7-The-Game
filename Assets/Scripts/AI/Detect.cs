using System.Collections;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;


//used to detect audio and visual sources
public class Detect : MonoBehaviour
{
    public bool Played = false;
    //getting the wander script
    [SerializeField] BasicWander wander;

    public GameObject player;

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

        //gets the target position to move to
        Vector3 targetDir = player.transform.position - transform.position;
    
        //get the forward vector3
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z), fwd * viewLength, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - 0.75f, transform.position.z), fwd * viewLength, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z), fwd * viewLength, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.75f, transform.position.z), fwd * viewLength, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1.25f, transform.position.z), fwd * viewLength, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1.75f, transform.position.z), fwd * viewLength, Color.green);


        //if it hits something then proceed

        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), fwd, out objectHit, viewLength))
        {
             agent.speed = 0;
        }
        else {
            agent.speed = 8;
        }

        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y- 0.75f, transform.position.z), fwd, out objectHit, viewLength))
        {
            agent.speed = 0;
        }
        else
        {
            agent.speed = 8;
        }
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1.25f, transform.position.z), fwd, out objectHit, viewLength))
        {
            agent.speed = 0;
        }
        else
        {
            agent.speed = 8;
        }
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.75f, transform.position.z), fwd, out objectHit, viewLength))
        {
            agent.speed = 0;
        }
        else
        {
            agent.speed = 8;
        }
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1.75f, transform.position.z), fwd, out objectHit, viewLength))
        {
            agent.speed = 0;
        }
        else
        {
            agent.speed = 8;
        }
    }
}
