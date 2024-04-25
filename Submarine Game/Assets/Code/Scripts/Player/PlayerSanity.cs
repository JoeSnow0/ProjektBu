using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSanity : MonoBehaviour
{
    [SerializeField] Slider sanitySlider;
    [SerializeField] FloatReference mCurrentSanity; 
    [SerializeField] FloatReference mMaxSanity;
    float mMinSanity = 0;
    [SerializeField] TriggerChecker mTriggerChecker;
    [SerializeField] LayerMask mSanityDrainMask;
    [SerializeField] float defaultDrainAmount = 1f;
    [SerializeField] bool canDie = true;

    private void Start()
    {
        mCurrentSanity.value = mMaxSanity.value;
        mTriggerChecker.layerToCheck = mSanityDrainMask;
    }

    //Function to call to clamp sanity value between min and max values;
    private void ClampSanity(float numberToClamp)
    {
        Mathf.Clamp(numberToClamp, mMinSanity, mMaxSanity.value);
    }
    //Function to call to increase sanity
    void addSanity(float amount)
    {
        mCurrentSanity.value += amount;
        ClampSanity(mCurrentSanity.value);
    }
    //Function to call to reduce sanity
    void SubtractSanity(float amount)
    {
        mCurrentSanity.value -= amount;
        ClampSanity(mCurrentSanity.value);
    }
    //What happens if the player loses all sanity
    void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void Update()
    {
        sanitySlider.value = mCurrentSanity.value;
        if(canDie && mCurrentSanity.value <= mMinSanity)
        {
            Death();
        }
        CheckCollisionWithEnemyTrigger();
    }
    void CheckCollisionWithEnemyTrigger()
    {
        if (mTriggerChecker.isInTrigger)
        {
            if ((mSanityDrainMask & (1 << mTriggerChecker.GetColliderOfTarget().gameObject.layer)) != 0)
            {
                SubtractSanity(defaultDrainAmount * Time.deltaTime);
            } 
        }
    }
}
