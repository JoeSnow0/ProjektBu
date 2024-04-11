using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{

    GameObject target;
    private void Start()
    {
        FindTarget();
    }
    private void Update()
    {
        FollowTarget();
    }
    void FindTarget()
    {
        target = FindObjectOfType<PlayerController>().gameObject;
    }
    void FollowTarget()
    {
        if (target != null)
        {
            transform.LookAt(target.transform.position);
        }
    }

}
