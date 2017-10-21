﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPillsControl : MonoBehaviour {

    public GameObject pill;
    public GameObject[] spawns;
    public float spawnTime = 3f;
    public List<GameObject> pillList;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = UnityEngine.Random.Range(0, spawns.Length);

        // Create an instance of the pill prefab at the randomly selected spawn point's position and rotation.
        pillList.Add(Instantiate(pill, spawns[spawnPointIndex].transform.position, spawns[spawnPointIndex].transform.rotation));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
