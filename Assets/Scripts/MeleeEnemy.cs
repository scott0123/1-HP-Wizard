using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MeleeEnemy : Enemy {

    private double attackDistance;

    protected override void Attack()
    {
        //End game round
        Debug.Log("You Died.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    protected override void GetHit(string source)
    {
        hp--;
    }

    protected override void Move()
    {
        agent.destination = player.transform.position;
        if ((this.transform.position - player.transform.position).magnitude <= attackDistance)
        {
            Attack();
        }
    }

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.transform.position;

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
