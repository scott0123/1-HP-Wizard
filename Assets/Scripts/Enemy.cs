using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MoveableObject {

    protected int hp;
    protected NavMeshAgent agent;
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected abstract void Move();

    protected void CheckDead()
    {
        if (hp <= 0)
        {
            gameObject.SetActive(false);
            EnemyWizard.minionCount--;
        }
    }

    protected abstract void Attack();

    protected abstract void GetHit(string source);
}
