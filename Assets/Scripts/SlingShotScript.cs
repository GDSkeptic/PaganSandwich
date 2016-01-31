using UnityEngine;
using System.Collections;

public class SlingShotScript : MonoBehaviour {

    float Left_Timer = 0.0f;
    [SerializeField]
    GameObject Left;
    [SerializeField]
    GameObject Left_Spawner;
    float Right_Timer = 0.0f;
    [SerializeField]
    GameObject Right;
    [SerializeField]
    GameObject Right_Spawner;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Left_Timer -= Time.deltaTime;
        Right_Timer -= Time.deltaTime;

        if (Left_Timer <= 0)
        {
            Instantiate(Left, Left_Spawner.transform.position, Left_Spawner.transform.rotation);
            Left_Timer = Random.Range(7, 20);
        }

        if (Right_Timer <= 0)
        {
            Instantiate(Right, Right_Spawner.transform.position, Right_Spawner.transform.rotation);
            Right_Timer = Random.Range(7, 20);
        }

    }
}
