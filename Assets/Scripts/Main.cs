﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.SetResolution(1024, 768, true, 60);
	}
	
	// Update is called once per frame
	void Update () {
		// here goes main rendering

	}

    private void FixedUpdate()
    {
        // here goes render for fixed rates
    }
}
