using UnityEngine;
using System.Collections;

public class Ingredient : MonoBehaviour
{
    Ray ray;
    Transform originalPosition;//original Position
    Vector3 offset;

    // Use this for initialization
    void Start()
    {
        originalPosition = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (SlingShotParent.obj != null)//if there is no obj already selected
            {
                SlingShotParent.obj = MousePick.GetObject(out ray);
                if (SlingShotParent.obj != null)//if there is actually an obj
                {
                    if (SlingShotParent.obj.tag == gameObject.tag)
                    {
                        // gameObject.transform.position = sling.transform.position;
                        //Vector3 vec = sling.transform.position;
                        //vec.y += 2.0f;
                        //gameObject.transform.position = vec;
                        //gameObject.transform.parent = sling.transform
                        offset = SlingShotParent.obj.transform.position - ray.origin;


                    }
                }
            }
            else if(SlingShotParent.obj.tag == tag)
            {
                transform.position = new Vector3(ray.origin.x + offset.x, transform.position.y, ray.origin.z + offset.z);
            }
        }
    }
}
