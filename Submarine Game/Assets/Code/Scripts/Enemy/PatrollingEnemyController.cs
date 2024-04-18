using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Patrol))]

public class PatrollingEnemyController : EnemyController
{

    private void Start()
    {
        //mStates[0] is the default state
        mStates = GetComponents<EnemyStates>();
        mCurrentState = mStates[0].mState;
    }
    private void Update()
    {
        
    }
    void SetState(EnemyState newState)
    {
        mCurrentState = newState;
    }
}
