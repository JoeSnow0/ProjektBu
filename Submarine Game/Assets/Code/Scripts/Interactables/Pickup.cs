using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{
    public Keys key;
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
