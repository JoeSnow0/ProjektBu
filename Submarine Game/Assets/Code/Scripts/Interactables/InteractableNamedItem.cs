using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNamedItem : Interactable
{

    public override void InteractionTriggered()
    {
        Debug.Log("This item is activated from somewhere else");
    }
}
