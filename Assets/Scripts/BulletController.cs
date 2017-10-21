﻿using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour {

    public Text lifepoints;
    
    // Use this for initialization
	void Start () {
        GameObject lifepoints = GameObject.FindWithTag("Lifepoints");
        if(lifepoints != null)
        {
            print(lifepoints);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Child"){
            GameObject child = collision.gameObject;
            ChildController.getInstance().childrenList.Remove(child);
            Destroy(child);
            Destroy(gameObject);
            LifepointsController.AddScore();
            
        }
    }
}
