using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Patrol))]

public class PatrollingEnemyController : EnemyController
{

    //public AudioSource mAudioSource;
    private void Start()
    {
        //mStates[0] is the default state
        mStates = GetComponents<EnemyStates>();
        mCurrentState = mStates[0].mState;

        mAudioManager = FindObjectOfType<AudioManager>();
        mAudioManager.PlaySound(1, mAudioSource, true);
    }
    private void Update()
    {
        
    }
    void SetState(EnemyState newState)
    {
        mCurrentState = newState;
    }
}
