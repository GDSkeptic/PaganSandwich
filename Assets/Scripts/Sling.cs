using UnityEngine;
using System.Collections;

public class Sling : MonoBehaviour
{

    // Use this for initialization
    public Ray ray;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (SlingShotParent.obj == null)//if there is no obj already selected
            {
                SlingShotParent.obj = MousePick.GetObject(out ray);
                if (SlingShotParent.obj.tag == "Sling" && SlingShotParent.obj.tag!=null)
                {
                   SlingShotParent.obj = null;
                }
            }
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            if (SlingShotParent.obj)
            {
                SlingShotParent.obj.GetComponent<Ingredient>().Reset();
                SlingShotParent.obj = null;
            }
        }
        if (SlingShotParent.obj != null)
        {
            float distance_to_screen = Camera.main.WorldToScreenPoint(SlingShotParent.obj.transform.position).z;
            Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
            SlingShotParent.obj.transform.position = new Vector3(pos_move.x, SlingShotParent.obj.transform.position.y, pos_move.z);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        SlingShotParent.obj = null;
        Destroy(other.gameObject);
        Debug.Log("ok");
        other.gameObject.transform.position = transform.position;
        Vector3 vec = transform.position;
        vec.y += 2.0f;
        other.gameObject.transform.position = vec;
        other.gameObject.transform.parent = transform;
    }
}
