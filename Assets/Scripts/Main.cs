using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    public int childrenToKill = 20;
    private int childrenKilled = 0;

    private bool levelEnded = false;
    private bool gameEnded = false;

	// Use this for initialization
	void Start () {
        Screen.SetResolution(1024, 768, true, 60);
	}
	
	// Update is called once per frame
	void Update () {
        // here goes main rendering
        endLevel();
        endGame();
	}

    private void FixedUpdate()
    {
        // here goes render for fixed rates
    }

    public void endLevel()
    {
        if (childrenKilled >= childrenToKill)
        {
            levelEnded = true;
        }
    }

    public void endGame()
    {
        // if last level scene!? end game -> show credits
    }
}
