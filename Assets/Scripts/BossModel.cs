﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossModel : MonoBehaviour {

    public Animator animator;
    public int hitpoints = 10;
    private int hitsConsumed = 0;
    public Transform player;
    public float bossMoveSpeed = 100f;
    public AudioClip bossScream;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.FindWithTag("Player");
        if (hitpoints <= 0)
        {
            Destroy(gameObject);
            LifepointsController.AddScore("bosskill");
            AudioSource.PlayClipAtPoint(bossScream, Camera.main.transform.position, 1f);
            FindObjectOfType<Main>().SetBossDefeated();
        }
        float step = bossMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Shoe")
        {
            Destroy(collision.gameObject);
            LifepointsController.AddScore("bosshit");
            hitpoints--;
            animator.SetTrigger("hit");

        }
        if(collision.gameObject.tag == "Football")
        {
            Destroy(collision.gameObject);
            LifepointsController.AddScore("bosshit");
            hitpoints -= 5;
            animator.SetTrigger("hit");
        }
    }
}
