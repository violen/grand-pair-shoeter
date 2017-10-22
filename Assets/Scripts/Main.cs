using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    public int childrenToKill = 20;
    private int childrenKilled = 0;

    private bool levelEnded = false;
    private bool gameEnded = false;

    private bool showMenu = false;
    private bool gamePaused = false;

	// Use this for initialization
	void Start () {
        Screen.SetResolution(1024, 768, true, 60);
	}

    // Update is called once per frame
    void Update()
    {
        // here goes main rendering
        endLevel();
        endGame();

        if (Input.GetKeyDown("escape"))
        {
            if (!gamePaused)
            {
                showMenu = true;
                Time.timeScale = 0;
            } else
            {
                ResumeGame();
            }
        }
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
            Debug.Log("Level Ended");
            if (SceneManager.GetActiveScene().name == "levelstandard")
            {
                FindObjectOfType<LoadManager>().LoadLevel("strandlevel");
            }
        }
    }

    public void endGame()
    {
        // if last level scene!? end game -> show credits
    }

    public void killedAChild()
    {
        childrenKilled += 1;
    }

    private void ResumeGame()
    {
        gamePaused = false;
        showMenu = false;
        Time.timeScale = 1;
    }

    private void OnGUI()
    {
        if (showMenu == true)
        {
            GUI.BeginGroup(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 90));

            GUI.Box(new Rect(0, 0, 100, 90), "Pause");
            if (GUI.Button(new Rect(10, 30, 80, 20), "Resume"))
            {
                ResumeGame();
            }
            if (GUI.Button( new Rect(10, 60, 80, 20), "Exit"))
            {
                Application.Quit();
            }

            GUI.EndGroup();
        }
    }
}
