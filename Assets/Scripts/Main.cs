using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Main : MonoBehaviour {

    public int childrenToKill = 20;
    private int childrenKilled = 0;
    private bool bossDefeated = false;

    private bool levelEnded = false;
    private bool gameEnded = false;
    private bool gameOver = false;

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
        EndLevel();
        EndGame();
        GameOver();

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

    public void EndLevel()
    {
        if (childrenKilled >= childrenToKill)
        {
            if (bossDefeated)
            {
                levelEnded = true;
                Debug.Log("Level Ended");
                ChangeLevel();
            } else
            {
                if (LevelHasBoss())
                {
                    BossSpawn.GetInstance().ReleaseTheBeast();
                } else
                {
                    // fallback if not all lvls get a Boss ;)
                    levelEnded = true;
                    ChangeLevel();
                }
            }
            
        }
    }

    private void ChangeLevel()
    {
        if (SceneManager.GetActiveScene().name == "levelstandard")
        {
            FindObjectOfType<LoadManager>().LoadLevel("strandlevel");
        }
        else if (SceneManager.GetActiveScene().name == "strandlevel")
        {
            FindObjectOfType<LoadManager>().LoadLevel("fussball");
        }
    }

    private bool LevelHasBoss()
    {
        String[] bossLevels = { "none", /* "levelstandard" , "strandlevel", "fussball" */};
        foreach (var level in bossLevels)
        {
            if (level.Contains(SceneManager.GetActiveScene().name)) return true;
        }
        return false;
    }

    public void EndGame()
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

    private void GameOver()
    {
        float lifePoints = FindObjectOfType<LifepointsController>().GetLifepoints();
        if (lifePoints <= 0)
        {
            // load GameOver


            // placeholder show pause....
            showMenu = true;
            Time.timeScale = 0;
        }
    }
}
