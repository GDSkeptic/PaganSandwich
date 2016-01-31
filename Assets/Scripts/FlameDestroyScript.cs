using UnityEngine;
using System.Collections;

public class FlameDestroyScript : MonoBehaviour {

    float Timer = 5.0f;

	// Use this for initialization
	void Start () {    
	}
	
	// Update is called once per frame
	void Update () {

        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            Destroy(gameObject);
        }

	}
}
