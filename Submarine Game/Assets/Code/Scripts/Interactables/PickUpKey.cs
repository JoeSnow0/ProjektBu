using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : Pickup
{
    public Key mKey;
    public override void InteractionTriggered()
    {
        Destroy(gameObject);
    }
}
