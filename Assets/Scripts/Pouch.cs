using UnityEngine;
using System.Collections;

public class Pouch : MonoBehaviour
{
    public Ray ray;
    public Vector3 initialPosition;
    [SerializeField]
    AudioClip[] audio;
    public void Reset()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.localPosition = initialPosition;
    }

    void Update()
    {
        GetComponent<LineRenderer>().SetPosition(1, transform.position + new Vector3(0, 0, -.25f));


        if (Input.GetButtonDown("Fire1"))
        {
            if (SlingShotParent.obj == null)
            {
                SlingShotParent.obj = MousePick.GetObject(out ray);
                if (SlingShotParent.obj != null && SlingShotParent.obj.tag != "Sling")
                {
                    SlingShotParent.obj = null;
                }
                else
                    GetComponent<AudioSource>().PlayOneShot(audio[Random.Range(0, audio.Length)]);

            }
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            if (SlingShotParent.obj && SlingShotParent.obj.tag == "Sling")
            {
                SlingShotParent.obj = null;
            }
        }
        if (SlingShotParent.obj != null && SlingShotParent.obj.tag == "Sling")
        {
            float distance_to_screen = Camera.main.WorldToScreenPoint(SlingShotParent.obj.transform.position).z;
            Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
            SlingShotParent.obj.transform.position = new Vector3(pos_move.x, SlingShotParent.obj.transform.position.y, pos_move.z);
        }
    }
    void OnCollisionEnter(Collision _collision)
    {
        if (_collision.gameObject.tag == "Stopper")
        {
            Reset();
        }
    }

}
