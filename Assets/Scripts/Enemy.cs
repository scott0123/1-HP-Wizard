using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MoveableObject {

    protected int hp;
    protected NavMeshAgent agent;
    public GameObject player;
    protected double frozen;

	// Use this for initialization
	void Start () {
        frozen = 0;
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

    public void Freeze(string source)
    {
        frozen = 5.0f;
    }

    protected void GetHit(string source)
    {
        if (source == "Spell")
        {
            hp--;
        }
        else if (source == "Lightning")
        {
            hp--;
        }
        else
        {
            hp -= 5;
        }
    }
}
