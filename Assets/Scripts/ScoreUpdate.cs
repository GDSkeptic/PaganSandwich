using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreUpdate : MonoBehaviour
{
    //this script will be attached to the  UI.

    private float Score;
    public int MatchStreak;
    private int prevStreak;
    private float ComboMeter;
    public int MissNum;
    public Text ScoreText;
    public Text ComboText;
    public Text MissText;
    
    

    // Use this for initialization
    void Start()
    {
        
        Score = 0.0f;
        ComboMeter = 1.0f;
        prevStreak = 0;
        MissNum = 0;
        UpdateCombo(MatchStreak);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateCombo(MatchStreak);
        UpdateMiss(MissNum);
        
    }




    public void UpdateScore()
    {
        float Combo = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<ScoreUpdate>().ComboMeter;
        float tempScore = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<ScoreUpdate>().Score;
        float Reward = 50.0f;
        //score update
        tempScore = (Combo * Reward) + tempScore;
        ScoreText.text = "Score: " + Score.ToString();
        GameObject.FindGameObjectWithTag("UICanvas").GetComponent<ScoreUpdate>().Score = tempScore;
    }

    void UpdateCombo(int Streak)
    {

        // if the streak is bigger than two and bigger than the last streak at check the combo meter increases.
        if (Streak > 2 && Streak > prevStreak)
        {
            ComboMeter += .5f;
            prevStreak = Streak;
            ComboText.text = "Combo: " + ComboMeter.ToString() + "x";
            
        }
        else
        {
            // if the streak is not bigger than the last streak or two, then ComboMeter 
            // is not incremented and streak is set to previous streak.
            ComboMeter = 1.0f;
            prevStreak = Streak;
            ComboText.text = "Combo: " + ComboMeter.ToString() + "x";
            

        }
    }

    void UpdateMiss(int TotalMiss)
    {
        MissText.text = "Misses: " + TotalMiss + "/15";
    }
}

