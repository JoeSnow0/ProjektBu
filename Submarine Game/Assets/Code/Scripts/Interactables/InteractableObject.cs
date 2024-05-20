using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableObject : Interactable
{
    [Header("Door References")]
    [Tooltip("Assign before start")]
    [SerializeField] MeshRenderer DoorFrame;
    [SerializeField] float animationSpeed = 1f;
    [SerializeField] Animator mAnim;
    [Header("Door State")]
    [Tooltip("Toggle if you want the door to be unlocked at start")]
    public bool unlocked;
    bool isPlaying = false;
    AnimatorStateInfo animStateInfo;
    private float NormalizedTime;
    private void Start()
    {
        DoorFrame.material.color = Color.red;
        if (unlocked)
        {
            DoorFrame.material.color = Color.green;
        }
    }
    private void Update()
    {
        checkAnimationIsPlaying();
    }
    //Checks if the currently active animation has finished its animation
    private void checkAnimationIsPlaying()
    {
        animStateInfo = mAnim.GetCurrentAnimatorStateInfo(0);
        NormalizedTime = animStateInfo.normalizedTime;

        if (NormalizedTime > 1.0f)
        {
            isPlaying = true;
        }
        else
        {
            isPlaying = false;
        }
    }
    /// <summary>
    /// Triggers when the player interacts with the object
    /// </summary>
    public override void InteractionTriggered()
    {
        if (isPlaying! && unlocked && mAnim.GetBool("Opened"))
        {
            OpenDoor(false);
        }
        else if (isPlaying! && unlocked && !mAnim.GetBool("Opened"))
        {
            OpenDoor(true);
        }
    }
    /// <summary>
    /// Open or close the door based on input
    /// </summary>
    public void OpenDoor(bool state)
    {
        if (isPlaying! && unlocked)
        {
            TriggerAnimation(state);
        }
    } 
    /// <summary>
    /// Unlock the door so it can be opened and closed
    /// </summary>
    public void UnlockDoor(bool state)
    {
        unlocked = state;
        Debug.Log("Door is unlocked");
        if(state)
        {
            DoorFrame.material.color = Color.green;
        }
        else
        {
            DoorFrame.material.color = Color.red;
        }
    }
    /// <summary>
    /// switches between the open and close animation
    /// </summary>
    /// <param name="state"></param>
    private void TriggerAnimation(bool state)
    {

        //Flips the bool which should trigger the animation to play
        mAnim.SetBool("Opened", state);
        isPlaying = true;
        mAnim.speed = animationSpeed;

    }

}
