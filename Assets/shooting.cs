﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{

    public Transform BulletStart;
    public GameObject ShotObject;

    public float ShotForce = 60000f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireShot();
        }
    }
    //Firing the Shot Function...
    void FireShot()
    {
        // Gets the instance of the specific shot...
        GameObject Bullet = Instantiate(ShotObject, BulletStart.position, BulletStart.rotation);

        Rigidbody rb = Bullet.GetComponent<Rigidbody>();
        // Adds Impulse to the shot
        rb.AddForce(BulletStart.up * ShotForce * Time.deltaTime);

    }
}
