using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InteractableButton : Interactable
{
    [SerializeField] AudioManager mAudioManager; 
    [SerializeField] AudioSource mAudioSource;
    [SerializeField] ControlPanel panel;
    [SerializeField] char number;
    [SerializeField] TextMeshPro textMesh;
    private void Start()
    {
        textMesh.text = mItemName.ToString();
        mAudioManager = FindObjectOfType<AudioManager>();
        mAudioSource = GetComponent<AudioSource>();
    }
    public override void InteractionTriggered()
    {
        panel.AddLetter(number);
        //Debug.Log("Added: " + number);
        //mAudioManager.PlaySound(1, mAudioSource, false);
    }
}
