using UnityEngine;
using System.Collections;

public class Sling : MonoBehaviour
{
    GameObject currentContainer;
    // Use this for initialization0
    public Ray ray;
    int noOfIngredient;
    public GameObject container;//parent ingredient if any
    public bool hasEmptyContainer;
    [SerializeField]
    float upValue = 1.0f; //offset y position of the object when dragged on the slingshot
    void Start()
    {
        currentContainer = Instantiate(container);
        hasEmptyContainer = false;
        noOfIngredient = 0;
    }

    bool IsIngredient(GameObject _obj)
    {
        return _obj.tag == "Tomato" || _obj.tag == "Cheese" || _obj.tag == "Pikkle" || _obj.tag == "Steak";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (SlingShotParent.obj == null)//if there is no obj already selected
            {
                SlingShotParent.obj = MousePick.GetObject(out ray);
                if (SlingShotParent.obj != null && !IsIngredient(SlingShotParent.obj))
                {
                    SlingShotParent.obj = null;
                }
            }
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            if (SlingShotParent.obj && IsIngredient(SlingShotParent.obj))
            {
                SlingShotParent.obj.GetComponent<Ingredient>().Reset();
                SlingShotParent.obj = null;
            }
        }
        if (SlingShotParent.obj != null && IsIngredient(SlingShotParent.obj) && SlingShotParent.obj.GetComponent<Ingredient>().SpawnerBox)
        {
            float distance_to_screen = Camera.main.WorldToScreenPoint(SlingShotParent.obj.transform.position).z;
            Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
            SlingShotParent.obj.transform.position = new Vector3(pos_move.x, SlingShotParent.obj.transform.position.y, pos_move.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (IsIngredient(other.gameObject) && other.gameObject.GetComponent<Ingredient>().SpawnerBox && noOfIngredient<3)
        {
            noOfIngredient++;
            hasEmptyContainer = false;
            SlingShotParent.obj = null;
            Vector3 vec = transform.position;
            vec.y += upValue;
            upValue += 0.2f;
            other.gameObject.GetComponent<Ingredient>().Reset();
            GameObject temp = (GameObject)Instantiate(other.gameObject, vec, Quaternion.identity);
            temp.GetComponent<Ingredient>().SpawnerBox = false;
            temp.transform.parent = currentContainer.transform;
            currentContainer.AddComponent<FixedJoint>().connectedBody = temp.GetComponent<Rigidbody>();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Container" && !hasEmptyContainer)
        {
            currentContainer.GetComponent<Container>().shot = true;
            Destroy(currentContainer, 30.0f);
            currentContainer = Instantiate(container);
            hasEmptyContainer = true;
            upValue = 1.0f;
            noOfIngredient = 0;
        }
    }
}
