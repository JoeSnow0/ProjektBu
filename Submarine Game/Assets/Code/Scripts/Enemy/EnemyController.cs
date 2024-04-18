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
    public enum EnemyState { Patrol, Chase };
    public EnemyStates[] mStates;
    public Transform raycastOrigin;
    public LayerMask playerMask;
    public LayerMask obstacleMask;
    public LayerMask checkMask;
}
