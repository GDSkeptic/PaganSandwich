using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Container : MonoBehaviour
{

    // Use this for initialization
    public bool shot;
    public float destroyTime = 30.0f;//destroy time for container
    void Start()
    {
        shot = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Bread" && shot)
        {
            Debug.Log("DETACH");
            Debug.Log(other.gameObject.tag);
            shot = false;
            int size = transform.childCount;
            List<GameObject> a = new List<GameObject>();
            for (int i = size - 1; i >= 0; i--)
            {
                Destroy(transform.GetChild(i).gameObject, 10.0f);
                a.Add(transform.GetChild(i).gameObject);
                transform.GetChild(i).gameObject.GetComponent<Rigidbody>().useGravity = true;
                transform.GetChild(i).parent = null;
            }
            foreach (FixedJoint b in GetComponents<FixedJoint>())
                b.connectedBody = null;
            for (int i = 0; i < a.Count; i++)
            {
                Vector3 vec = a[i].transform.up;
                int x = Random.Range(-45,45);
                int z = Random.Range(-45, 45);
                vec = Quaternion.Euler(x, 0, z) * vec;
                a[i].GetComponent<Rigidbody>().AddForce(vec * 500);
            }
        }
        else if(other.gameObject.tag == "Bread" && shot)
        {
            Debug.Log("ATTACH");
            shot = false;
            Debug.Log(transform.childCount);
            for (int i = transform.childCount-1; i >=0; i--)
            {
                //transform.GetChild(i).gameObject.GetComponent<Rigidbody>().useGravity = true;
                Vector3 vec = transform.GetChild(i).position;
                vec.y -= 0.5f;
                transform.GetChild(i).position = vec;
                other.gameObject.AddComponent<FixedJoint>().connectedBody = transform.GetChild(i).GetComponent<Rigidbody>();
                transform.GetChild(i).parent = other.gameObject.transform;
                Debug.Log(i);
            }
            foreach (FixedJoint b in GetComponents<FixedJoint>())
                b.connectedBody = null;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
           Destroy(gameObject);
        }
    }
}
