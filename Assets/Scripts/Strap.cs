﻿using UnityEngine;
using System.Collections;

public class Strap : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<LineRenderer>().SetPosition(1, transform.position + new Vector3(0, 0, .25f));
    }
}
