using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLock : Interactable
{

    [SerializeField] Key requiredKey;
    [SerializeField] MeshRenderer[] KeyDisplay;
    public InteractableObject TargetToUnlock;

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
                        TargetToUnlock.UnlockDoor(true);
                        return;
                    }

                }
                //If you don't have the key do this
                Debug.Log("You are missing a key");
            }
        }
        if (requiredKey == null)
        {
            TargetToUnlock.UnlockDoor(true);
        }
    }
}
