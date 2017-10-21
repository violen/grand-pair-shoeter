using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildController : MonoBehaviour {

    public GameObject child;
    public Transform[] spawns;
    public float spawnTime = 3f;
    public List<GameObject> childrenList;
    private float childSpeed = 2f;

    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = UnityEngine.Random.Range(0, spawns.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        childrenList.Add(Instantiate(child, spawns[spawnPointIndex].position, spawns[spawnPointIndex].rotation));
    }

    void Update ()
    {
        foreach ( var child in childrenList )
        {
            child.transform.position -= Vector3.left * childSpeed * 1 * Time.deltaTime;
        }
    }
}
