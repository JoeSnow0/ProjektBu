using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableObject : Interactable
{
    [SerializeField] float animationSpeed = 1f;
    [SerializeField] Animator mAnim;
    bool opened = false;
    [SerializeField] Key requiredKey;
    bool isPlaying = false;
    AnimatorStateInfo animStateInfo;
    public float NormalizedTime;
    [SerializeField] MeshRenderer[] KeyDisplay;
    private void Start()
    {
        if(requiredKey != null)
        {
            foreach(var key in KeyDisplay)
            {
                key.material = requiredKey.KeyMaterial;
            }
        }
    }
    private void Update()
    {
        checkAnimationIsPlaying();
    }
    //Checks if the currently active animation has finished its animation
    private void checkAnimationIsPlaying()
    {
        animStateInfo = mAnim.GetCurrentAnimatorStateInfo(0);
        NormalizedTime = animStateInfo.normalizedTime;

        if (NormalizedTime > 1.0f)
        {
            isPlaying = true;
        }
        else
        {
            isPlaying = false;
        }
    }
public override void InteractionTriggered()
    {
        KeyCheck();
    }
    private void KeyCheck()
    {
        if(requiredKey != null)
        {
            //Get keys from player in scene
            List<Key> checkKeys = FindAnyObjectByType<PlayerInteraction>().myKeys;
            //Make the player has any keys at all
            if (checkKeys != null)
            {
                //Check for correct key
                foreach (Key key in checkKeys)
                {
                    if (key == requiredKey)
                    {
                        //You found the key, play the animation!
                        TriggerAnimation();
                        return;
                    }

                }
                //If you don't have the key do this
                Debug.Log("You are missing a key");
            }
        }
        if(requiredKey == null)
        {
            TriggerAnimation();
        }
    }
    private void TriggerAnimation()
    {
        if (isPlaying!)
        {
            //Flips the bool which should trigger the animation to play
            mAnim.SetBool("Opened", !mAnim.GetBool("Opened"));
            isPlaying = true;
            mAnim.speed = animationSpeed;
        }
    }
    
}
