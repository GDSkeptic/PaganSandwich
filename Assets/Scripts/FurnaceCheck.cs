using UnityEngine;
using System.Collections;

public class FurnaceCheck : MonoBehaviour {

    public delegate void PunchSandwich();

    public event PunchSandwich OnPunchSandwich;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider _other)
    {
        GameObject ObjectToTest = _other.gameObject;
        Bread bread = ObjectToTest.GetComponent<Bread>();
        Ingredient[] stuff = ObjectToTest.GetComponentsInChildren<Ingredient>();
        if(bread.RequestedIngredients.Count != stuff.Length)
        {
            // bad sandwich!!!
            if (OnPunchSandwich != null)
                OnPunchSandwich();
        }
        foreach(Ingredient i in stuff)
        {
            bool found = false;
            for (int s = 0; s < bread.RequestedIngredients.Count; ++s)
            {
                if (i.tag == bread.RequestedIngredients[s])
                {
                    found = true;
                    bread.RequestedIngredients.RemoveAt(s);
                    break;
                }
            }
            if (!found && OnPunchSandwich != null)
            {
                OnPunchSandwich();
                break;
            }
        }
    }

}
