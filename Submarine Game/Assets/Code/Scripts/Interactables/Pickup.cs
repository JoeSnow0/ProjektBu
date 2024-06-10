using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{
    [Header("Assign enemies to spawn when item is picked up, or leave blank")]
    public StaticEnemyController[] controller;

    public override void InteractionTriggered()
    {
    }
    public void TriggerStaticEnemy()
    {
        if (controller != null)
        {
            foreach (var enemy in controller) 
            {
                enemy.ActivateEnemy();
            }
        }
    }
}
