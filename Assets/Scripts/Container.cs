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
            shot = false;
            int size = transform.childCount;
            List<GameObject> a = new List<GameObject>();
            for (int i = size - 1; i >= 0; i--)
            {
                Destroy(transform.GetChild(i).gameObject,2.0f);
                a.Add(transform.GetChild(i).gameObject);
                transform.GetChild(i).gameObject.GetComponent<Rigidbody>().useGravity = true;
                transform.GetChild(i).gameObject.GetComponent<BoxCollider>().enabled = false;
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
            Destroy(gameObject);

        }
        else if(other.gameObject.tag == "Bread" && shot)
        {
            foreach (FixedJoint b in GetComponents<FixedJoint>())
                b.connectedBody = null;
            shot = false;
            float z = -0.8f;
            for (int i = transform.childCount-1; i >=0; i--)
            {
                transform.GetChild(i).gameObject.GetComponent<Rigidbody>().useGravity = false;
                Vector3 vec = transform.GetChild(i).position;
                vec.y = other.gameObject.transform.GetChild(1).position.y + 0.1f;
                vec.x = other.gameObject.transform.GetChild(1).position.x - 0.1f;
                vec.z = other.gameObject.transform.GetChild(1).position.z + z;
                z += 0.8f;
                transform.GetChild(i).position = vec;
                other.gameObject.AddComponent<FixedJoint>().connectedBody = transform.GetChild(i).GetComponent<Rigidbody>();
                transform.GetChild(i).parent = other.gameObject.transform;
            }
            Vector3 tempVelocity = other.gameObject.GetComponent<Rigidbody>().velocity;
            tempVelocity.x = tempVelocity.y= 0;
            tempVelocity.z = 5;
            other.gameObject.GetComponent<Rigidbody>().velocity = tempVelocity;
            for (int i = 2; i < other.gameObject.transform.childCount; i++)
            {
                other.gameObject.transform.GetChild(i).GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            GetComponent<Rigidbody>().velocity = Vector3.zero;
           Destroy(gameObject);
        }
    }
}
