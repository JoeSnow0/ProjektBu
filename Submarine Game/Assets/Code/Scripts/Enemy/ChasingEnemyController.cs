using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Chase))]
public class ChasingEnemyController : EnemyController
{
    private void Start()
    {
        //mStates = FindObjectsByType<EnemyStates>();
    }
    private void Update()
    {
        if (playerChecker.isInTrigger)
        {
            Collider other = playerChecker.GetColliderOfTarget();

            Vector3 direction = other.transform.position - raycastOrigin.position;
            float distance = Vector3.Distance(other.transform.position, raycastOrigin.position);
            RaycastHit hit;
            Physics.Raycast(raycastOrigin.position, direction, out hit, distance, checkMask, queryTriggerInteraction: QueryTriggerInteraction.Ignore);
            if (hit.collider != null)
            {
                if ((obstacleMask & (1 << hit.transform.gameObject.layer)) != 0)
                {
                    IsTargetSeen = false;
                }
                if ((playerMask & (1 << hit.transform.gameObject.layer)) != 0)
                {
                    Debug.Log("Can see player, begin chase");
                    //mStates[0].DeactivateState();
                    //mStates[1].ActivateState();
                    IsTargetSeen = true;
                }
            }

        }
    }
}
