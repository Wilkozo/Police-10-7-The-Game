﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "bullet" || other.tag == "Player") {
            Destroy(this.gameObject);
        }    
    }

}
