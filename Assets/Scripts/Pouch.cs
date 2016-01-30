using UnityEngine;
using System.Collections;

public class Pouch : MonoBehaviour
{
    public Vector3 initialPosition;

    void OnCollisionEnter(Collision _collision)
    {
        if(_collision.gameObject.tag == "Stopper")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.localPosition = initialPosition;
        }
    }

}
