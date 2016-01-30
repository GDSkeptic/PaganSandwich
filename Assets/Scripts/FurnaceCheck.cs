using UnityEngine;
using System.Collections;

public class FurnaceCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider _other)
    {
        GameObject ObjectToTest = _other.gameObject;
        Bread bread = ObjectToTest.GetComponent<Bread>();
        Ingredient[] stuff = ObjectToTest.GetComponentsInChildren<Ingredient>();
    }

}
