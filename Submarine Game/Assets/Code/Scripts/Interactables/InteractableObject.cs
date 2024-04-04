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
        //Flips the bool which should trigger the animation to play
        mAnim.SetBool("Opened", !mAnim.GetBool("Opened"));
        mAnim.speed = animationSpeed;
    }
    
}
