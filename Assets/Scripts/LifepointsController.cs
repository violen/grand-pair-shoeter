using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifepointsController : MonoBehaviour {

    public Text text;
    public static float lifepoints = 100f;
    static public int score = 0;

    static int maxLifepoints = 100;
    float r;

	// Use this for initialization
	void Start () {
        text.text = "Score: " + score + " \n " + "Lifepoints: " + lifepoints;
        InvokeRepeating("ContinuouslyReduceLifepoints", 0.5f, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
        lifepoints -= Time.deltaTime;
    }

    private void Awake()
    {
        // set lifepoints on level change
        if (lifepoints < 100) lifepoints = 100f;
    }

    void ContinuouslyReduceLifepoints()
    {     
        text.text = "Score: " + score + " \n " + "Lifepoints: " + (int) lifepoints;
    }

    public float GetLifepoints()
    {
        return lifepoints;
    }

    public static void IncreaseLifePoints()
    {
        lifepoints += 40;
        if (lifepoints > maxLifepoints)
        {
            lifepoints = lifepoints - (lifepoints - maxLifepoints);
        }
        AddScore("takePill");
    }

    public static void AddScore(String eventname)
    {
        switch (eventname)
        {
            case "childkill":
                score += 100;
                break;
            case "bosshit":
                score += 50;
                break;
            case "bosskill":
                score += 300;
                break;
            case "takePill":
                score += 150;
                break;
        }

    }
    

    public static void DecreaseLifePoints(String eventname)
    {
        var decrease = 0;
        switch (eventname)
        {
            case "childhit":
                var levelname = SceneManager.GetActiveScene().name;
                String[] stages = { "fussball", "strandlevel", "levelstandard" };

                decrease = 10;
                break;
            case "bosshit":
                decrease = 100;
                break;
        }
        if (decrease > 0)
        {
            if ((lifepoints - decrease) <= 0)
            {
                lifepoints = 0;
                return;
            }
            lifepoints -= decrease;
        }
    }
}
