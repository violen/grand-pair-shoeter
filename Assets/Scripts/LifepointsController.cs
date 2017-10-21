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
        
	}

    void ContinuouslyReduceLifepoints()
    {
        lifepoints--;
        text.text = "Score: " + score + " \n " + "Lifepoints: " + lifepoints;
    }

    public float GetLifepoints()
    {
        return lifepoints;
    }

    public static void increaseLifePoints()
    {
        lifepoints += 40;
        if (lifepoints > maxLifepoints)
        {
            lifepoints = lifepoints - (lifepoints - maxLifepoints);
        }
        AddScore();
    }

    public static void AddScore()
    {
        score += 100;
    }

    /* Testmethode, um die Pillen zu simulieren
    void GetLife()
    {
        r = Random.value;
        if (r > 0.9)
        {
            lifepoints = lifepoints + 20;
            print("Life is life");
            if(lifepoints > maxLifepoints)
            {
                lifepoints = lifepoints - (lifepoints - maxLifepoints);
            }
            score += 100;
        }
    }*/
}
