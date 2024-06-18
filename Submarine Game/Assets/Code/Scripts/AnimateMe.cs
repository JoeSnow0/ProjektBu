using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateMe : MonoBehaviour
{
    [SerializeField] TriggerChecker checker;
    Animator mAnimator;
    [SerializeField] string mAnimStateName;

    private void Start()
    {
        mAnimator = GetComponent<Animator>(); 
    }

    private void Update()
    {
        if(checker != null)
        {
            if(checker.isInTrigger)
            {
                mAnimator.SetBool(mAnimStateName, true);
            }
        }
    }
}
