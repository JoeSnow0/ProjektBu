using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    
    public enum EnemyState { Patrol, Chase };
    public EnemyState enemyState = EnemyState.Patrol; 
    NavMeshSurface mNavMeshSurface;
    [SerializeField] Patrol mPatrol;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] LayerMask playerMask;
    private void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((playerMask & (1 << other.gameObject.layer)) != 0)
        {
            //Vector3 direction = other.transform.position - raycastOrigin.position;
            //RaycastHit hit;
            //Physics.Raycast(raycastOrigin.position, direction, out hit, 5f, playerMask, queryTriggerInteraction: QueryTriggerInteraction.Collide);
            //if(hit.collider != null)
            //{
                
            //}
            mPatrol.PausePatrol(); 
            enemyState = EnemyState.Chase;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if ((playerMask & (1 << other.gameObject.layer)) != 0)
        {
            mPatrol.ResumePatrol();
            enemyState = EnemyState.Patrol;
        }
    }
}
