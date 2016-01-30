using UnityEngine;
using System.Collections;

public class GlobalGameScript : MonoBehaviour {

    public float Game_Speed = 1.0f;
    float Spawn_Bread_Timer = 0.0f;
    float Threshold = 5.0f;
    public GameObject Bread;
	// Use this for initialization
	void Start () {
        //Bread = GameObject.FindGameObjectWithTag("Bread");
	}
	
    void FixedUpdate()
    {
        Spawn_Bread_Timer += Time.deltaTime * (Game_Speed + (Game_Speed * .75f)) ;
    }

	// Update is called once per frame
	void Update () {

        if (Spawn_Bread_Timer >= Threshold)
        {
            Instantiate(Bread);
            Spawn_Bread_Timer = 0.0f;
        }

	}
}
