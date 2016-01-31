using UnityEngine;
using System.Collections;

public class GlobalGameScript : MonoBehaviour
{

    [SerializeField]
    float GameTimer = 0;
    public float[] LevelTimes;
    public float[] LevelSpeeds;
    public float Game_Speed = 0.5f;
    float Spawn_Bread_Timer = 0.0f;
    float Threshold = 5.0f;
    public GameObject Bread;
    public GameManager GM;


    // Use this for initialization
    void Start()
    {
        if (LevelTimes == null || LevelTimes.Length < 8)
        {
            LevelTimes = new float[8];
            LevelSpeeds = new float[8];
        }
        LevelTimes[0] = 0;
        LevelTimes[1] = 30;
        for (int i = 2; i < 8; ++i)
        {
            LevelTimes[i] = 30 + 15 * (i - 1);
        }
        LevelSpeeds[0] = .5f;
        for (int i = 1; i < 7; ++i)
        {
            LevelSpeeds[i] = .5f + .25f * i;
        }
        LevelSpeeds[7] = 2.5f;
        //Bread = GameObject.FindGameObjectWithTag("Bread");
    }

    void FixedUpdate()
    {
        Spawn_Bread_Timer += Time.deltaTime * (Game_Speed + (Game_Speed * .75f));

        if (Spawn_Bread_Timer >= Threshold)
        {
            Instantiate(Bread);
            Spawn_Bread_Timer = 0.0f;
        }
        GameTimer += Time.deltaTime;
        for (int i = LevelTimes.Length - 1; i >= 0; --i)
        {
            if (GameTimer > LevelTimes[i])
            {
                if (Game_Speed != LevelSpeeds[i] && i % 2 == 0)
                    GM.AdvanceMusic();
                Game_Speed = LevelSpeeds[i];
                break;
            }
        }
    }
}
