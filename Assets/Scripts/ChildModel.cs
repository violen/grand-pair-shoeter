using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildModel : MonoBehaviour {

    public float speed = 1;
    public float resistance = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pille")
        {
            speed = speed * 2;
            spawnPillsControl.getInstance().pillList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

}
