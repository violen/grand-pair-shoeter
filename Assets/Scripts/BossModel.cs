using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossModel : MonoBehaviour {

    public int hitpoints = 20;
    private int hitsConsumed = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(hitpoints <= 0)
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Shoe")
        {
            Destroy(collision.gameObject);
            hitpoints--;
        }
        if(collision.gameObject.tag == "Football")
        {
            Destroy(collision.gameObject);
            hitpoints -= 5;
        }
    }
}
