using UnityEngine;
using System.Collections;

public class SlingShotParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        col.gameObject.transform.position = gameObject.transform.position;
        col.gameObject.transform.parent = gameObject.transform;
    }
}
