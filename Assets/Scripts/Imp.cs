using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Imp : MeleeEnemy {
    protected override void Move()
    {
        agent.destination = player.transform.position;
        if ((this.transform.position - player.transform.position).magnitude <= attackDistance)
        {
            Attack();
        } 

        if (agent.baseOffset > 1.0f)
        {
            agent.baseOffset -= 0.05f;
        }
    }

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.transform.position;
        agent.baseOffset = 3.0f;

        attackDistance = 1.0f;
        hp = 1;
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
