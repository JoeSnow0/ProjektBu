using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]


public class PlayerInteraction : MonoBehaviour
{
    //A script that fires a raycast in the direction the player is facing from the centre of the camera view.
    //If it collides with anything interactable, get its name and display it on the UI
    [SerializeField] Camera mCam;
    public List<Key> myKeys =  new List<Key>();
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask interactableMask;
    [SerializeField] AudioSource mAudioSource;
    AudioManager mAudioManager;
    Vector3 origin;
    Vector3 direction;
    bool mInteractInput;
    [SerializeField] PlayerUIController mPlayerUIPrefab;
    [SerializeField] PlayerUIController mPlayerUI;

    private void Start()
    {
        mAudioSource = GetComponent<AudioSource>();
        mAudioManager = FindAnyObjectByType<AudioManager>();
        if (mPlayerUI == null)
        {
            mPlayerUI = FindObjectOfType<PlayerUIController>();
            if (mPlayerUI == null)
            {
                mPlayerUI = Instantiate(mPlayerUIPrefab);
            }
        }
        mPlayerUI.NotesPanel.gameObject.SetActive(false);
        mPlayerUI.InteractablePanel.gameObject.SetActive(false);
        mPlayerUI.interactableHUDText.text = "";
        mPlayerUI.NotesText.text = "";
        myKeys.Clear();
    }
    public void InteractInput(InputAction.CallbackContext context)
    {
        //Get the input from the assigned Input from the Player Input
        mInteractInput = false;
        mInteractInput = context.action.WasPressedThisFrame();
        //Debug.Log("Look Input: " + mInteractInput);
    }
    //Checks if what you're looking at is an interactable, shoots a raycast from the camera in the direction its looking
    RaycastHit CheckInteractable()
    {
        origin = mCam.transform.position;
        direction = mCam.transform.forward;
        RaycastHit hit;
        Physics.Raycast(origin, direction, out hit, maxDistance, interactableMask, queryTriggerInteraction: QueryTriggerInteraction.Ignore);
        return hit;
        
    }
    //Attempts to trigger a function on the interactable
    void AttemptInteraction()
    {
        if(mInteractInput)
        {
            RaycastHit hit = CheckInteractable();
            if (hit.collider != null)
            {
                if(hit.transform.GetComponent<InteractableNamedItem>() != null)
                {

                }
                //Check for notes
                if (hit.transform.GetComponent<InteractableNotes>() != null)
                {
                    //Grab the text
                    string text = hit.transform.gameObject.GetComponent<InteractableNotes>().myText.text;
                    if (text != null)
                    {
                        mPlayerUI.NotesText.text = text;
                    }
                    else
                    {
                        mPlayerUI.NotesText.text = "Missing text file";
                    }
                    mPlayerUI.NotesPanel.gameObject.SetActive(true);
                }
                else
                {
                    mPlayerUI.NotesPanel.gameObject.SetActive(false);
                }
                //check for pickups
                if (hit.transform.GetComponent<PickUpKey>() != null)
                {
                    //add key to player
                    myKeys.Add(hit.transform.GetComponent<PickUpKey>().mKey);
                    mAudioManager.PlaySound(0, mAudioSource, false);

                }
                if ((interactableMask & (1 << hit.transform.gameObject.layer)) != 0)
                {
                    hit.transform.GetComponent<Interactable>().InteractionTriggered();
                }
            }
        }
    }
    //Updates the HUD: if the player is looking at an interactable, add its name to the screen, clear when looking away
    void UpdateHUD()
    {
        RaycastHit hit = CheckInteractable();
        if(hit.collider != null)
        {
            if(hit.transform.gameObject.GetComponent<Interactable>() != null)
            {
                mPlayerUI.interactableHUDText.text = hit.transform.gameObject.GetComponent<Interactable>().mItemName;
                mPlayerUI.InteractablePanel.gameObject.SetActive(true);
            }
        }
        else
        {
            mPlayerUI.InteractablePanel.gameObject.SetActive(false);
            mPlayerUI.interactableHUDText.text = "";
            mPlayerUI.NotesPanel.gameObject.SetActive(false);
            mPlayerUI.NotesText.text = "";
        }
    }
    private void Update()
    {
        UpdateHUD();
        AttemptInteraction();
    }
    private void LateUpdate()
    {
        //reset the interact input, this prevents the player from constantly triggering the door animation(or other interactable animation)
        mInteractInput = false;
    }
}
