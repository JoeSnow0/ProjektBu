using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InteractableButton : Interactable
{
    [SerializeField] ControlPanelCode panel;
    [SerializeField] char number;
    [SerializeField] TextMeshPro textMesh;
    private void Start()
    {
        textMesh.text = mItemName.ToString();
    }
    public override void InteractionTriggered()
    {
        panel.AddLetter(number);
        //Debug.Log("Added: " + number);
        //mAudioManager.PlaySound(1, mAudioSource, false);
    }
}
