using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLock : Interactable
{
    [Header("Assign Key and door")]
    [SerializeField] Key requiredKey;
    public DoorHolder TargetToUnlock;
    [Header("These should already be assigned")]
    [SerializeField] MeshRenderer[] KeyDisplay;
    [SerializeField] Light mLight;
    [SerializeField] MeshRenderer mLightbulb;

    private void Start()
    {
        if (requiredKey != null)
        {
            foreach (var key in KeyDisplay)
            {
                key.material = requiredKey.KeyMaterial;
            }
        }
    }
    public override void InteractionTriggered()
    {
        KeyCheck();
    }
    public void KeyCheck()
    {
        if (requiredKey != null)
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
                        Unlock();
                        return;
                    }

                }
                //If you don't have the key do this
                Debug.Log("You are missing a key");
            }
        }
        if (requiredKey == null)
        {
            Unlock();
        }
    }
    private void Unlock()
    {
        TargetToUnlock.myObject.UnlockDoor(true);
        mLight.color = Color.green;
        mLightbulb.material.SetColor("_EmissionColor", Color.green);
    }
}
