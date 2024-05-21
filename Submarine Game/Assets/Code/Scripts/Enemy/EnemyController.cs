using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class EnemyController : MonoBehaviour
{
    //Internal Refs
    [Header("Player References")]
    [Tooltip("Internal References (assigned before start)")]
    public LayerMask playerMask;
    public LayerMask obstacleMask;
    public LayerMask checkMask;
    public Transform raycastOrigin;
    public TriggerChecker playerChecker;
    public AudioSource mAudioSource;
    public ParticleSystem mParticleSystem;

    //External Refs
    [Header("External References")]
    [Tooltip("found at start, make sure its in the scene")]
    public AudioManager mAudioManager;
    NavMeshSurface mNavMeshSurface;


    public bool IsTargetSeen = false;
    public enum EnemyState { Patrol, Chase, Freeze };
    public EnemyStates[] mStates;
    public EnemyState mCurrentState;

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
