using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Bear : MeleeEnemy {

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.transform.position;

        attackDistance = 4.0f;
        hp = 10;
    }
	
	// Update is called once per frame
	void Update () {
        Move();
    }
    
    protected override void Attack()
    {
        Animator ani = this.GetComponentInChildren<Animator>();
        ani.SetBool("attack", true);
        Invoke("KillPlayer", 1.2f);
    }

    void KillPlayer(){

        //End game round
        Animator ani = this.GetComponentInChildren<Animator>();
        ani.SetBool("attack", false);
        Debug.Log("You Died.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
