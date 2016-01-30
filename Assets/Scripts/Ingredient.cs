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
  
    void OnCollisionEnter(Collision other)
    {
        SlingShotParent.obj = null;
        // Destroy(other);
        Debug.Log("ok");
        transform.position = other.gameObject.transform.position;
        Vector3 vec = other.gameObject.transform.position;
        vec.y += 2.0f;
        gameObject.transform.position = vec;
        gameObject.transform.parent = other.gameObject.transform;
    }
}
