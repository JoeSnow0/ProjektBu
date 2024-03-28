using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{
    public Keys myKeys;
    public override void InteractionTriggered()
    {
        Debug.Log("You have picked up an item");
        Destroy(gameObject);
    }
}
