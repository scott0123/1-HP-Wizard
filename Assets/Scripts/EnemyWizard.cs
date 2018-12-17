using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWizard : RangedEnemy {
    public static int minionCount = 0;
    private static bool invincible;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.transform.position;
        agent.baseOffset = 1.5f;

        hp = 30;
        invincible = true;
        attackDistance = 38.0f;

        fireInterval = 5.0f;
        fireTimer = fireInterval;
        firePositionOffset = new Vector3(0, 0.5f, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        if (invincible)
            hp = 30;

        if (minionCount == 0)
        {
            attackDistance = 11.0f;
            invincible = false;
            fireInterval = 1.0f;
            fireTimer = fireInterval;
            minionCount--;
        }

        Move();
    }
}
