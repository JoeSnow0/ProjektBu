using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Patrol))]
[RequireComponent(typeof(AudioSource))]

public class PatrollingEnemyController : EnemyController
{

    //public AudioSource mAudioSource;
    private void Start()
    {
        //mStates[0] is the default state
        mStates = GetComponents<EnemyStates>();
        SetState(mStates[0].mState);

        mAudioManager = FindObjectOfType<AudioManager>();
        mAudioSource = GetComponent<AudioSource>();
        mAudioManager.PlaySound(1, mAudioSource, true);
        mAudioManager.PlaySound(1, mAudioSource, true, AudioManager.AudioType.SFX, 10f);
        if(!mNavMeshAgent.isOnNavMesh)
        {
            SetState(EnemyState.disabled);
        }
    }
    private void Update()
    {
        
    }
    void SetState(EnemyState newState)
    {
        mCurrentState = newState;
    }
}
