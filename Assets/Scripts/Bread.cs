using UnityEngine;
using System.Collections;

public class Bread : MonoBehaviour {

    public string[] RequestedIngredients;

    public float BreadHeight = 1;

    [SerializeField]
    float CurrentSandwichHeight = 1;

    void Start()
    {
        CurrentSandwichHeight = BreadHeight;
    }

    void OnCollisionEnter(Collision _collision)
    {
        GameObject other = _collision.gameObject;
        if(other.tag == "Tomatoe" || other.tag == "Lettuce" || other.tag == "Steak" || other.tag == "Chicken")
        {
            other.GetComponent<Rigidbody>().velocity = Vector3(0, 0, 0);
            other.transform.rotation = Quaternion.Euler(0, 0, 0);
            other.transform.position = transform.position + Vector3.up * CurrentSandwichHeight;
            CurrentSandwichHeight += other.GetComponent<Ingredient>().height;
            other.transform.parent = transform;
        }
    }
}
