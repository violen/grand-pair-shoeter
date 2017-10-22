using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButtonAnime : MonoBehaviour {

        public MaskableGraphic restartButton;
        
        public float interval = 1f;
        public float startDelay = 0.5f;
        public bool currentState = true;
        public bool defaultState = true;
        bool isBlinking = false;
       


	// Use this for initialization
	void Start () {
        restartButton.enabled = defaultState;
        StartBlink();
	}

    public void StartBlink()
    {
        if (isBlinking)
            return;
        if (restartButton != null)
        {
            isBlinking = true;
            InvokeRepeating("ToggleState", startDelay, interval);
        }
    }
	
    public void ToggleState()
    {
        restartButton.enabled = !restartButton.enabled;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
