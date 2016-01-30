using UnityEngine;
using System.Collections;

public class Ingredient : MonoBehaviour
{
    Vector3 originalPosition;//original Position
    public float height;
    // Use this for initialization
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Reset()
    {
        transform.position = originalPosition;
    }
  
 
}
