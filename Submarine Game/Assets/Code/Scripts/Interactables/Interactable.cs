using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class Interactable : MonoBehaviour
{
    public AudioManager mAudioManager;
    public AudioSource mAudioSource;
    //All Interactables have a name
    [Header("Assign this")]
    public string mItemName;

    private void Start()
    {
        mAudioManager = FindObjectOfType<AudioManager>();
        mAudioSource = GetComponent<AudioSource>();
    }
    public abstract void InteractionTriggered();
}
