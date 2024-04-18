using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Chase : EnemyStates
{
    [SerializeField] EnemyController enemyController;
    [SerializeField] float chaseTimeIfOutOfRange = 5f;
    float timer = 0f;
    private int destPoint = 0;
    float minDistanceBeforeMovingOn = 0.2f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        mState = EnemyController.EnemyState.Chase;
    }


    void UpdateTargetPosition()
    {
        // Set the agent to update the destination.
        agent.destination = target.position;
    }
    void Timer()
    {
        if (enemyController.IsTargetSeen)
        {
            resetTimer();
        }
        timer += Time.deltaTime;
        if(timer >= chaseTimeIfOutOfRange)
        {
            DeactivateState();
        }
    }
    void resetTimer()
    {
        timer = 0f;
    }

    void Update()
    {
        UpdateTargetPosition();
        Timer();
    }
    public override void ActivateState()
    {
        enemyController.mCurrentState = mState;
    }
    public override void DeactivateState()
    {
        enemyController.mCurrentState = EnemyController.EnemyState.Patrol;
    }
}
