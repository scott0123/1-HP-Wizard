using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Jaguar : MeleeEnemy {

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.transform.position;
        agent.speed = 2.0f;

        attackDistance = 1.0f;
        hp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
