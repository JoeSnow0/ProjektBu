using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public abstract class ControlPanel : MonoBehaviour
{
    public AudioManager mAudioManager;
    public AudioSource mAudioSource;
    public InteractableObject TargetToUnlock;
    public bool panelDone = false;
    private void Start()
    {
        mAudioManager = FindObjectOfType<AudioManager>();
        mAudioSource = GetComponent<AudioSource>();
    }
   
}
