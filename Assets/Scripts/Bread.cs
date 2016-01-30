﻿using UnityEngine;
using System.Collections.Generic;

public class Bread : MonoBehaviour {

    public List<string> RequestedIngredients;

    public float BreadHeight = 1;

    [SerializeField]
    float CurrentSandwichHeight = 1;

    void Start()
    {
        RequestedIngredients = new List<string>(2);
        CurrentSandwichHeight = BreadHeight;
    }

    void OnCollisionEnter(Collision _collision)
    {
        GameObject other = _collision.gameObject;
        if(other.tag == "Tomatoe" || other.tag == "Lettuce" || other.tag == "Steak" || other.tag == "Chicken")
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
        if(_trigger.tag == "Furnace")
            Destroy(gameObject);
    }
}
