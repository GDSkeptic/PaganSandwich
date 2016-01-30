using UnityEngine;
using System.Collections;

public class Sling : MonoBehaviour
{

    // Use this for initialization
    public Ray ray;
    public bool ingredientParent;//if there is a parent already created
    public GameObject parentIngredient;//parent ingredient if any
    [SerializeField]
    float upValue = 1.0f; //offset y position of the object when dragged on the slingshot
    void Start()
    {
      ingredientParent=false;
    }

    bool IsIngredient(GameObject _obj)
    {
        return _obj.tag == "Tomato" || _obj.tag == "Chicken" || _obj.tag == "Lettuce" || _obj.tag == "Steak";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (SlingShotParent.obj == null)//if there is no obj already selected
            {
                SlingShotParent.obj = MousePick.GetObject(out ray);
                if (SlingShotParent.obj !=null && !IsIngredient(SlingShotParent.obj) )
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

    void OnTriggerEnter(Collider other)
    {
        if (IsIngredient(other.gameObject) && other.gameObject.GetComponent<Ingredient>().SpawnerBox)
        {
            SlingShotParent.obj = null;
            // Destroy(other.gameObject);
            //Debug.Log("ok");
            //other.gameObject.transform.position = transform.position;
            Vector3 vec = transform.position;
            vec.y += upValue;
            upValue += 0.2f;
            //other.gameObject.transform.position = vec;
            //other.gameObject.transform.parent = transform;
            if (ingredientParent == false)
            {
                parentIngredient = (GameObject)Instantiate(other.gameObject, vec, Quaternion.identity);
                ingredientParent = true;
                parentIngredient.GetComponent<Ingredient>().SpawnerBox = false;
            }
            else
            {
                GameObject temp = (GameObject)Instantiate(other.gameObject, vec, Quaternion.identity);
                temp.transform.parent = parentIngredient.transform;
                temp.GetComponent<Ingredient>().SpawnerBox = false;
            }
            other.gameObject.GetComponent<Ingredient>().Reset();
        }
    }
}
