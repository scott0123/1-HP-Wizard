using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWizard : RangedEnemy {
    public static int minionCount;

    // Use this for initialization
    void Start()
    {
        //temporary code
        minionCount = 4;
        //end tmpcode
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.transform.position;

        hp = 20;

        attackDistance = 15.0f;

        fireInterval = 5.0f;
        fireTimer = fireInterval;
        firePositionOffset = new Vector3(0, 0.5f, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        if (minionCount == 0)
        {
            attackDistance = 8.0f;

            fireInterval = 1.0f;
            fireTimer = fireInterval;
            minionCount--;
        }

        Move();
    }
}
