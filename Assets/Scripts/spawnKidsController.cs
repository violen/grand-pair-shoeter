using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnKidsController : MonoBehaviour {

    public GameObject kids;
    public float interval = 3;



	// Use this for initialization
	void Start () {
        InvokeRepeating("spawnKids", interval, interval);
	}
	
	void spawnKids() {
        float v = Random.value;

        if (v < .60)
        {
            GameObject g = (GameObject)Instantiate(kids, transform.position, Quaternion.identity);
        }
	}
}
