using UnityEngine;
using System.Collections;

public class SlingSHot : MonoBehaviour {
    
    public Vector3 mouse_Position;
    //the object I want to rotate
    public Transform target;
    public Vector3 objectPosition;
    public float angle;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //record the position of the mouse cursor
        mouse_Position = Input.mousePosition;
        //distance between the mouse and the camera
        mouse_Position.z = 6f;
        //mouse_Position.x = mouse_Position.x - objectPosition.x;
        //mouse_Position.y = mouse_Position.y - objectPosition.y;
        objectPosition = Camera.main.ScreenToWorldPoint(target.position);
        angle = Mathf.Atan2(mouse_Position.x,mouse_Position.y);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}
}
