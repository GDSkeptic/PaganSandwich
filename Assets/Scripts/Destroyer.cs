﻿using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {

        Destroy(other.transform.parent.gameObject);
    }

}
