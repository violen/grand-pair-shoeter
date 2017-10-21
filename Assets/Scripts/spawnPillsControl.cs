using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPillsControl : MonoBehaviour {

    public GameObject pill;
    public Transform[] spawns;
    public float spawnTime;
    public List<GameObject> pillList;

 
    // Use this for initialization
    void Start () {
        if (pillList.Count < 1)
        {
            spawnTime = UnityEngine.Random.Range(0, 45);
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }
        
    }

    void Spawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = UnityEngine.Random.Range(0, spawns.Length);

        // Create an instance of the pill prefab at the randomly selected spawn point's position and rotation.
        if (pillList.Count < 1)
        {
            pillList.Add(Instantiate(pill, spawns[spawnPointIndex].position, spawns[spawnPointIndex].rotation));
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
