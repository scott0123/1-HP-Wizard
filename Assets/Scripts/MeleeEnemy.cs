using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MeleeEnemy : Enemy {

    protected double attackDistance;

    protected override void Attack()
    {
        //End game round
        Debug.Log("You Died.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    protected override void Move()
    {
        if ((this.transform.position - player.transform.position).magnitude <= attackDistance)
        {
            Attack();
        }
        CheckDead();
        agent.destination = player.transform.position;
    }

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.transform.position;

        attackDistance = 2.0f;
        hp = 1;
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}
}
