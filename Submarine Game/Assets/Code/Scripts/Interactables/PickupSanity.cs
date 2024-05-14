using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupSanity : Pickup
{
    [SerializeField]PlayerSanity sanity;
    [SerializeField]float amount; 
    private void Start()
    {
        sanity = FindObjectOfType<PlayerSanity>();
    }
    public override void InteractionTriggered()
    {
        sanity.addSanity(amount);
    }
}
