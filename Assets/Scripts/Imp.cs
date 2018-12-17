﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Imp : MeleeEnemy {
    protected override void Move()
    {
        base.Move();

        float player_dist = (this.transform.position - player.transform.position).magnitude;
        if (agent.baseOffset > 1.5f && player_dist < 5 * attackDistance)
        {
            agent.baseOffset -= Time.deltaTime;
        }
    }

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.transform.position;
        agent.baseOffset = 3.0f;

        attackDistance = 1.5f;
        hp = 1;
    }
	
	// Update is called once per frame
	void Update () {
        Move();
    }
}
