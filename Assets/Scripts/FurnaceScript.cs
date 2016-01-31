using UnityEngine;
using System.Collections;

public class FurnaceScript : MonoBehaviour
{

    float Red_Random = 0.0f;
    float Orange_Random = 0.0f;
    float Yellow_Random = 0.0f;
    float counter = 0.0f;
    float threshold = 0.05f;
    //public int Tempo = 0;

    // Use this for initialization
    void Start()
    {
        Red_Random = GameObject.FindGameObjectWithTag("Light_Red").GetComponent<Light>().range;
        Orange_Random = GameObject.FindGameObjectWithTag("Light_Orange").GetComponent<Light>().range;
        Yellow_Random = GameObject.FindGameObjectWithTag("Light_Yellow").GetComponent<Light>().range;
    }

    // Update is called once per frame
    void Update()
    {

        counter += Time.deltaTime;

        if (counter >= threshold)
        {
            counter = 0.0f;
            threshold = Random.Range(.04f, .06f);
            Red_Random = Random.Range(15.0f, 28.0f);
            Orange_Random = Random.Range(10.0f, 15.0f);
            Yellow_Random = Random.Range(2.6f, 3.0f);
        }

        //GameObject.FindGameObjectWithTag("Light_Red").GetComponent<Light>().range += (Red_Random - GameObject.FindGameObjectWithTag("Light_Red").GetComponent<Light>().range) * (Time.deltaTime * Tempo);
        //GameObject.FindGameObjectWithTag("Light_Orange").GetComponent<Light>().range += (Orange_Random - GameObject.FindGameObjectWithTag("Light_Orange").GetComponent<Light>().range) * (Time.deltaTime * Tempo);
        //GameObject.FindGameObjectWithTag("Light_Yellow").GetComponent<Light>().range += (Yellow_Random - GameObject.FindGameObjectWithTag("Light_Yellow").GetComponent<Light>().range) * (Time.deltaTime * Tempo);

        GameObject.FindGameObjectWithTag("Light_Red").GetComponent<Light>().range = Red_Random;
        GameObject.FindGameObjectWithTag("Light_Orange").GetComponent<Light>().range = Orange_Random;
        GameObject.FindGameObjectWithTag("Light_Yellow").GetComponent<Light>().range = Yellow_Random;

    }
}
