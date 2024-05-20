using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSendBool : Interactable
{
    [Header("Assigned by prefab")]
    [SerializeField] ControlPanelTimer controlPanel;

    public override void InteractionTriggered()
    {
        controlPanel.TimerReset();
    }

}
