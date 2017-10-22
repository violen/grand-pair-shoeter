using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonAnime : MonoBehaviour {

        public MaskableGraphic startButton;
        
        public float interval = 1f;
        public float startDelay = 0.5f;
        public bool currentState = true;
        public bool defaultState = true;
        bool isBlinking = false;
       


	// Use this for initialization
	void Start () {
        startButton.enabled = defaultState;
        StartBlink();
	}

    public void StartBlink()
    {
        if (isBlinking)
            return;
        if (startButton != null)
        {
            isBlinking = true;
            InvokeRepeating("ToggleState", startDelay, interval);
        }
    }
	
    public void ToggleState()
    {
        startButton.enabled = !startButton.enabled;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
