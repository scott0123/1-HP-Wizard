﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bear : MeleeEnemy {

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.transform.position;

        attackDistance = 1.0f;
        hp = 10;
    }
	
	// Update is called once per frame
	void Update () {
        Move();

        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}