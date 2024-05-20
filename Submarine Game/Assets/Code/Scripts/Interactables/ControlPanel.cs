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
    [Header("Assign this to a door you want unlocked")]
    public DoorHolder TargetToUnlock;
    [HideInInspector] public bool panelDone = false;
    private void Start()
    {
        mAudioManager = FindObjectOfType<AudioManager>();
        mAudioSource = GetComponent<AudioSource>();
    }
   
}
