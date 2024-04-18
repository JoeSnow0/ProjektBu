using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class EnemyController : MonoBehaviour
{

    public EnemyState mCurrentState;
    NavMeshSurface mNavMeshSurface;
    public TriggerChecker playerChecker;
    public bool IsTargetSeen = false;
    public enum EnemyState { Patrol, Chase, Freeze };
    public EnemyStates[] mStates;
    public Transform raycastOrigin;
    public LayerMask playerMask;
    public LayerMask obstacleMask;
    public LayerMask checkMask;
    public void Chase()
    {
        raycastOrigin.transform.gameObject.name = "test";
    }
    public void Patrol()
    {

    }
    public void Freeze()
    {

    }
    private void Update()
    {
        if(mCurrentState == EnemyState.Patrol)
        {
            Patrol();
        }
        if(mCurrentState == EnemyState.Freeze)
        {
            Freeze();
        }
    }
}
