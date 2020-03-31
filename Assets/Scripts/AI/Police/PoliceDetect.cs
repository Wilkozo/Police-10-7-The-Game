using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceDetect : MonoBehaviour
{

    public GameObject player;
    public NavMeshAgent agent;

    public bool chase;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        //find the player
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (chase) {
            agent.destination = player.transform.position;
            transform.LookAt(player.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        chase = true;
    }

    private void OnTriggerExit(Collider other)
    {
        chase = false;
    }
}
