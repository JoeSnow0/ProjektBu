using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemyController : EnemyController
{
    [SerializeField] Animator animator;
    [SerializeField] bool isActive;

    private void Start()
    {
        mParticleSystem.Stop();
        if(isActive)
        {
            ActivateEnemy();
        }
    }
    public void ActivateEnemy()
    {
        animator.SetBool("Start", true);
        mParticleSystem.Play();
    }
}
