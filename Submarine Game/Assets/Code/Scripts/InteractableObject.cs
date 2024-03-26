using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InteractableObject : Interactable
{
    [SerializeField] float animationSpeed = 1f;
    public override void InteractionTriggered()
    {
        Debug.Log("You have triggered an animation");
    }
    
}
