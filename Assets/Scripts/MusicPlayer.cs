using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer musicPlayer = null;

	// Use this for initialization
	void Start () {
		if(musicPlayer != null)
        {
            Destroy(gameObject);
        } else
        {
            musicPlayer = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
      
	}
}
