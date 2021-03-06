﻿using UnityEngine;
using System.Collections;

public class Conveyor_Belt : MonoBehaviour {

    public float Variable_Speed;
    public float conveyerTime = .75f;
    Rigidbody rigid_body;
    public float Constant_Speed = 150.0f;
    public float Variable_Force = 0.0f;

	// Use this for initialization
	void Start () {
	rigid_body  = GetComponent<Rigidbody>();
        Variable_Speed = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GlobalGameScript>().Game_Speed;
        GetComponent<AudioSource>().Play();
    }
	
    void FixedUpdate()
    {
        conveyerTime -= Time.deltaTime;
        Variable_Speed = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GlobalGameScript>().Game_Speed;
        Variable_Force = Constant_Speed * Variable_Speed;
        if(conveyerTime < 0)
        {
            conveyerTime = .75f;

            //rigid_body.position -= transform.forward * Variable_Speed * Time.deltaTime;
            rigid_body.position = Vector3.zero;
            rigid_body.velocity = Vector3.zero;
        }
        else
        {
            //rigid_body.MovePosition(rigid_body.position + transform.forward * Variable_Speed * Time.deltaTime);
            rigid_body.AddForce(new Vector3(0, 0, Variable_Force));

        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
