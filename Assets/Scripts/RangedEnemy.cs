using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemy : Enemy {

    protected double attackDistance;
    protected double fireInterval;
    protected double fireTimer;
    protected Vector3 firePositionOffset;

    public GameObject spell;

    protected override void Attack()
    {
        agent.destination = gameObject.transform.position;

        //fire at player
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0)
        {
            //fire (temp solution)
            Vector3 fireLocation = gameObject.transform.position + gameObject.transform.up * (firePositionOffset.y) + gameObject.transform.forward * (firePositionOffset.z);
            Vector3 directionVect = player.transform.position - fireLocation;
            GameObject instance = Instantiate(spell, fireLocation, Quaternion.LookRotation(directionVect) * Quaternion.Lerp(Quaternion.identity, Random.rotation, Random.Range(0.0f, 0.02f)));
            fireTimer = fireInterval;
        }
    }
    
    protected override void Move()
    {
        if ((this.transform.position - player.transform.position).magnitude <= attackDistance)
        {
            Attack();
        } else
        {
            agent.destination = player.transform.position;
            fireTimer = fireInterval;
        }
        CheckDead();
    }

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.transform.position;

        hp = 1;

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
