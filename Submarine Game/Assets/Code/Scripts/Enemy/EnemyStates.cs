using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyStates : MonoBehaviour
{
    //This is set in each states own start(). 
    public EnemyController.EnemyState mState;
    public NavMeshAgent agent;
    public Transform target;
    private void Start()
    {
        target = FindAnyObjectByType<PlayerController>().transform;
    }
    public abstract void ActivateState(); 
    public abstract void DeactivateState();

}
