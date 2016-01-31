using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public static class ScoreUpdate
{
    public static bool ShowMenuOnStartup = true;
    
    private static float Score;
    public static int MatchStreak;
    private static int prevStreak;
    private static float ComboMeter;
    public static int MissNum;
    public static Text ScoreText;
    public static Text ComboText;
    public static Text MissText;
    
    

    // Use this for initialization
    public static void Restart()
    {
        
        Score = 0.0f;
        ComboMeter = 1.0f;
        prevStreak = 0;
        MissNum = 0;
        UpdateCombo();

    }

    //// Update is called once per frame
    //void Update()
    //{
    //    UpdateCombo(MatchStreak);
    //    UpdateMiss(MissNum);
        
    //}




    public static void UpdateScore()
    {
        float Combo = ComboMeter;
        float tempScore = Score;
        float Reward = 50.0f;
        //score update
        tempScore = (Combo * Reward) + tempScore;
        ScoreText.text = "Score: " + Score.ToString();
        Score = tempScore;
    }

    public static void UpdateCombo()
    {

        // if the streak is bigger than two and bigger than the last streak at check the combo meter increases.
        if (MatchStreak > 2 && MatchStreak > prevStreak)
        {
            ComboMeter += .5f;
            prevStreak = MatchStreak;
            ComboText.text = "Combo: " + ComboMeter.ToString() + "x";
            
        }
        else
        {
            // if the streak is not bigger than the last streak or two, then ComboMeter 
            // is not incremented and streak is set to previous streak.
            ComboMeter = 1.0f;
            prevStreak = MatchStreak;
            ComboText.text = "Combo: " + ComboMeter.ToString() + "x";
            

        }
    }

    public static void UpdateMiss()
    {
        MissText.text = "Misses: " + MissNum + "/15";
    }
}

