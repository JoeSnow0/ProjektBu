using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    [SerializeField] LayerMask layerToCheck;
    public bool isInTrigger = false;
    Collider ColliderOfTarget;
    private void OnTriggerStay(Collider other)
    {
        if ((layerToCheck & (1 << other.gameObject.layer)) != 0)
        { 
            isInTrigger = true;
            ColliderOfTarget = other;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if ((layerToCheck & (1 << other.gameObject.layer)) != 0)
        {
            isInTrigger = false;
            ColliderOfTarget = null;
        }
    }
    public Collider GetColliderOfTarget()
    {
        return ColliderOfTarget;
    }
}
