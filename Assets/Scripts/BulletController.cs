﻿using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour {

    public AudioClip[] childScream;
    public Text lifepoints;
    
    // Use this for initialization
	void Start () {
        GameObject lifepoints = GameObject.FindWithTag("Lifepoints");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Child"){
            GameObject child = collision.gameObject;
            ChildController.getInstance().childrenList.Remove(child);
            Camera.main.GetComponent<Main>().killedAChild();
            Destroy(child);
            Destroy(gameObject);
            LifepointsController.AddScore("childkill");
            float randomScream = UnityEngine.Random.value;
            if(randomScream > 0.5f) { 
                AudioSource.PlayClipAtPoint(childScream[0], Camera.main.transform.position, 1f);
            } else
            {
                AudioSource.PlayClipAtPoint(childScream[1], Camera.main.transform.position, 1f);
            }
        }
    }
}
