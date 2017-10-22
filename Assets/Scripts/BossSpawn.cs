using System.ComponentModel.Design.Serialization;
using System.Security.Permissions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour {

    private Transform spawnPoint;
    public GameObject model;

    private static BossSpawn instance;

	// Use this for initialization
	void Start () {
        spawnPoint = gameObject.transform;
        if (instance == null)
        {
            instance = this;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReleaseTheBeast()
    {
        Instantiate(model, spawnPoint.position, spawnPoint.rotation);
    }

    public static BossSpawn GetInstance()
    {
        return instance;
    }
}
