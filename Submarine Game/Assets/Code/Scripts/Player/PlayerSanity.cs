using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSanity : MonoBehaviour
{
    [SerializeField] FloatReference mCurrentSanity; 
    [SerializeField] FloatReference mMaxSanity;
    float mMinSanity = 0;
    [SerializeField] TriggerChecker mTriggerChecker;
    [SerializeField] LayerMask mSanityDrainMask;
    [SerializeField] float defaultDrainAmount = 1f;
    [SerializeField] bool canDie = true;
    [SerializeField] PlayerUIController mPlayerUIPrefab;
    [SerializeField] PlayerUIController mPlayerUI;

    private void Start()
    {
        mCurrentSanity.value = mMaxSanity.value;
        mTriggerChecker.layerToCheck = mSanityDrainMask;
        if(mPlayerUI == null)
        {
            mPlayerUI = FindObjectOfType<PlayerUIController>();
             if(mPlayerUI == null)
            {
                mPlayerUI = Instantiate(mPlayerUIPrefab);
            }
        }
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
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("EndScene");
    }
    private void Update()
    {
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
