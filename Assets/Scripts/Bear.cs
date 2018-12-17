using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bear : MeleeEnemy {

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.transform.position;

        attackDistance = 1.7f;
        hp = 10;
    }
	
	// Update is called once per frame
	void Update () {
        Move();
    }
    
    protected override void Attack()
    {
        Animator ani = this.GetComponentInChildren<Animator>();
        ani.SetTrigger("attack")
        Invoke("KillPlayer", 0.8f)
    }

    void KillPlayer(){
        
        //End game round
        Debug.Log("You Died.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
