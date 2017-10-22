﻿using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildController : MonoBehaviour {

    public GameObject child;
    public Transform[] spawns;
    public float spawnTime;
    public List<GameObject> childrenList;
    public float childSpeed;
    public int maxSpawnSize;
    public static ChildController instance;

    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);

        if (instance == null)
        {
            instance = this;
        }
    }

    void Spawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = UnityEngine.Random.Range(0, spawns.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        if (childrenList.Count < maxSpawnSize)
            childrenList.Add(Instantiate(child, spawns[spawnPointIndex].position, spawns[spawnPointIndex].rotation));
    }

    void Update ()
    {
        GameObject childToDestroy = null;

        foreach ( var myChild in childrenList )
        {
            if (myChild == null) continue;

            ChildModel model = myChild.GetComponent<ChildModel>();
            var speed = model.speed;
            var newPos = Vector3.left * childSpeed * GetLevelFactor() * Time.deltaTime;
            myChild.transform.position += newPos * speed;
            if (myChild.transform.position.z < 1)
            {
                var pos = myChild.transform.position;
                myChild.transform.position = new Vector3(pos.x, pos.y, 1);
            }
            //Debug.Log("Childpos: " + myChild.transform.position.x);
            float distance = myChild.transform.position.z - Camera.main.transform.position.z;
            Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(-0.1f, 0, distance));
            if (myChild.transform.position.x < leftmost.x)
                childToDestroy = myChild;
        }

        if (childToDestroy != null)
        {
            childrenList.Remove(childToDestroy);
            Destroy(childToDestroy);
        }
    }

    public static ChildController getInstance()
    {
        return instance;
    }

    private float GetLevelFactor()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        switch(sceneName)
        {
            case "strandlevel":
                return 4.5f;
            case "fussball":
                return 7f;
            default:
                return 3f;
        }
    }
}
