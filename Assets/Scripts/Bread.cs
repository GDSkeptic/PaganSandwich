using UnityEngine;
using System.Collections.Generic;

public class Bread : MonoBehaviour {

    public List<string> RequestedIngredients;
    List<string> PossibleIngredients = new List<string>(4);

    [SerializeField]
    GameObject First;
    [SerializeField]
    GameObject Second;
    [SerializeField]
    GameObject Tomato;
    [SerializeField]
    GameObject Steak;
    [SerializeField]
    GameObject Cheese;
    [SerializeField]
    GameObject Pikkle;

    GameObject FirstPlace;
    GameObject SecondPlace;

    public float BreadHeight = 1;
    public float TimeToLive = 30.0f;

    [SerializeField]
    float CurrentSandwichHeight = 1;

    void Start()
    {
        RequestedIngredients = new List<string>(2);
        CurrentSandwichHeight = BreadHeight;
        PossibleIngredients.Add("Tomato");
        PossibleIngredients.Add("Steak");
        PossibleIngredients.Add("Cheese");
        PossibleIngredients.Add("Pikkle");

        for (int i = 0; i < 2; i++)
        {
            int temp = Random.Range(0, 3);
            RequestedIngredients.Add(PossibleIngredients[temp]);
        }

        if (RequestedIngredients[0] == "Tomato")
        {
            FirstPlace = Instantiate(Tomato);
            FirstPlace.transform.position = First.transform.position;
            FirstPlace.transform.parent = transform;
        }
        else if (RequestedIngredients[0] == "Steak")
        {
            FirstPlace = Instantiate(Steak);
            FirstPlace.transform.position = First.transform.position;
            FirstPlace.transform.parent = transform;

        }
        else if (RequestedIngredients[0] == "Cheese")
        {
            FirstPlace = Instantiate(Cheese);
            FirstPlace.transform.position = First.transform.position;
            FirstPlace.transform.parent = transform;
        }
        else if (RequestedIngredients[0] == "Pikkle")
        {
            FirstPlace = Instantiate(Pikkle);
            FirstPlace.transform.position = First.transform.position;
            FirstPlace.transform.parent = transform;
        }

        if (RequestedIngredients[1] == "Tomato")
        {
            SecondPlace = Instantiate(Tomato);
            SecondPlace.transform.position = Second.transform.position;
            SecondPlace.transform.parent = transform;
        }
        else if (RequestedIngredients[1] == "Steak")
        {
            SecondPlace = Instantiate(Steak);
            SecondPlace.transform.position = Second.transform.position;
            SecondPlace.transform.parent = transform;
        }
        else if (RequestedIngredients[1] == "Cheese")
        {
            SecondPlace = Instantiate(Cheese);
            SecondPlace.transform.position = Second.transform.position;
            SecondPlace.transform.parent = transform;
        }
        else if (RequestedIngredients[1] == "Pikkle")
        {
            SecondPlace = Instantiate(Pikkle);
            SecondPlace.transform.position = Second.transform.position;
            SecondPlace.transform.parent = transform;
        }

    }

    void Update()
    {
        TimeToLive -= Time.deltaTime;
        if (TimeToLive < 0)
            Destroy(gameObject);
    }

    void OnCollisionEnter(Collision _collision)
    {
        GameObject other = _collision.gameObject;
        if(other.tag == "Tomato" || other.tag == "Cheese" || other.tag == "Steak" || other.tag == "Pikkle")
        {
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.transform.rotation = Quaternion.Euler(0, 0, 0);
            other.transform.position = transform.position + Vector3.up * CurrentSandwichHeight;
            CurrentSandwichHeight += other.GetComponent<Ingredient>().height;
            other.transform.parent = transform;
        }
    }

    void OnTriggerEnter(Collider _trigger)
    {
        if (_trigger.tag == "Furnace") 
            Destroy(gameObject);
    }
}
