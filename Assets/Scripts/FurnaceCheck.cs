using UnityEngine;
using System.Collections;

public class FurnaceCheck : MonoBehaviour {

    public delegate void PunchSandwich();
    
    public event PunchSandwich OnPunchSandwich;
    GameObject ObjectToLaunch;
    Vector3 Cam;



    // Use this for initialization
    void Start () {
        Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider _other)
    {
        // Streak variable is updated when bread is checked for ingredients. 
        // If good streak goes up.
        // If bad streak is reset.
        // Streak is then sent to comboupdate in the score update script.

        GameObject ObjectToTest = _other.gameObject;
        Bread bread = ObjectToTest.transform.parent.GetComponent<Bread>();
        Ingredient[] stuff = ObjectToTest.GetComponentsInChildren<Ingredient>();

        if (bread.RequestedIngredients.Count != stuff.Length)
        {
            // bad sandwich!!!
            if (OnPunchSandwich != null)
            {
                OnPunchSandwich();
                //reseting the match streak to 0 and incrementing the number of misses.
                //ScoreUpdate.MatchStreak = 0;
                //ScoreUpdate.MissNum++;
            }

        }
        bool found = false;

        foreach (Ingredient i in stuff)
        {
            for (int s = 0; s < bread.RequestedIngredients.Count; ++s)
            {
                if (i.tag == bread.RequestedIngredients[s])
                {
                    found = true;

                    bread.RequestedIngredients.RemoveAt(s);
                    break;
                }
            }

        }
            if (!found && OnPunchSandwich != null)
            {
                OnPunchSandwich();
                //reseting the match streak to 0 and incrementing the number of misses.
                //ScoreUpdate.MatchStreak = 0;
                //ScoreUpdate.MissNum++;
            StartCoroutine(Eject());
            ObjectToLaunch = _other.gameObject.transform.parent.gameObject;
            }
            else
            {
                //// if the ingredients match the match streak is incremented and the score is updated.
                //ScoreUpdate.MatchStreak++;
                //ScoreUpdate.UpdateScore();
            }
    }

    IEnumerator Eject()
    {
        yield return new WaitForSeconds(.25f);
        ObjectToLaunch.GetComponent<Transform>().position = Vector3.MoveTowards(ObjectToLaunch.GetComponent<Transform>().position, Cam, 15);
    }

}
