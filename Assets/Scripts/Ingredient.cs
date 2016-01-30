using UnityEngine;
using System.Collections;

public class Ingredient : MonoBehaviour
{
    public GameObject sling;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject g = MousePick.GetObject();
            if (g != null)
            {
                if (g.tag == gameObject.tag)
                {
                    // gameObject.transform.position = sling.transform.position;
                    Vector3 vec = sling.transform.position;
                    vec.y += 2.0f;
                    gameObject.transform.position = vec;
                    gameObject.transform.parent = sling.transform;
                }
            }
        }
    }
}
