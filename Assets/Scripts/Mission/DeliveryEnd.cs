using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryEnd : MonoBehaviour
{
    MissionManager manager;

    private void Start()
    {
        manager = this.transform.parent.GetComponent<MissionManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            manager.endDeliveryMission();
        }
    }
}
