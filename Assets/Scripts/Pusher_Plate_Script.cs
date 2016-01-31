using UnityEngine;
using System.Collections;

public class Pusher_Plate_Script : MonoBehaviour {

    public FurnaceCheck furnaceCheck;
    [SerializeField]
    GameObject Furnace;
    //[SerializeField]
    //GameObject Pusher;

	// Use this for initialization
	void Start () {
        furnaceCheck.OnPunchSandwich += FurnaceCheck_OnPunchSandwich;
	}

    private void FurnaceCheck_OnPunchSandwich()
    {
        GetComponent<Animator>().SetTrigger("PunchIt");
        Furnace.GetComponent<Animator>().SetTrigger("Reject");
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Bread")
        {
            Vector3 temp = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position;
            other.transform.parent.GetComponent<Transform>().position = Vector3.MoveTowards(other.transform.parent.GetComponent<Transform>().position, temp, 10);

        }
    }
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Bread")
        {
            Vector3 temp = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position;
            other.gameObject.transform.parent.GetComponent<Transform>().position = Vector3.MoveTowards(other.gameObject.transform.parent.GetComponent<Transform>().position, temp, 10);

        }
    }
}
