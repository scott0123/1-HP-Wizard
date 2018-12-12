using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireDemon : RangedEnemy {

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.transform.position;

        hp = 20;

        attackDistance = 15.0f;

        fireInterval = 2.0f;
        fireTimer = fireInterval;
        firePositionOffset = new Vector3(0, 0.5f, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
