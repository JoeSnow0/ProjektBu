using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.AI;
using static EnemyController;

public class Patrol : EnemyStates
{
    [SerializeField] EnemyController enemyController;
    public Transform[] points;
    private int destPoint = 0;
    float minDistanceBeforeMovingOn = 0.2f;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        mState = EnemyController.EnemyState.Patrol;
        GotoNextPoint();
        
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (enemyController.mCurrentState == EnemyController.EnemyState.Patrol && !agent.pathPending && agent.remainingDistance < minDistanceBeforeMovingOn)
            GotoNextPoint();
    }
    public override void ActivateState()
    {
        agent.isStopped = false;
        enemyController.mCurrentState = mState;
    }
    public override void DeactivateState()
    {
        //agent.isStopped = true;
    }

}
