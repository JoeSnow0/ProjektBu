using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class PlayerInteraction : MonoBehaviour
{
    //A script that fires a raycast in the direction the player is facing from the centre of the camera view.
    //If it collides with anything interactable, get its name and display it on the UI
    [SerializeField] Camera mCam;
    public List<Key> myKeys =  new List<Key>();
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask interactableMask;
    [SerializeField] Image NotesPanel;
    [SerializeField] Image InteractablePanel;
    [SerializeField] TextMeshProUGUI interactableHUDText;
    [SerializeField] TextMeshProUGUI NotesText;
    Vector3 origin;
    Vector3 direction;
    bool mInteractInput;

    private void Start()
    {
        NotesPanel.gameObject.SetActive(false);
        InteractablePanel.gameObject.SetActive(false);
        interactableHUDText.text = "";
        NotesText.text = "";
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
                //Check for notes
                if(hit.transform.GetComponent<InteractableNotes>() != null)
                {
                    NotesText.text = hit.transform.gameObject.GetComponent<InteractableNotes>().myText.text;
                    NotesPanel.gameObject.SetActive(true);
                }
                else
                {
                    NotesPanel.gameObject.SetActive(false);
                }
                //check for pickups
                if (hit.transform.GetComponent<PickUpKey>() != null)
                {
                    //add key to player
                    myKeys.Add(hit.transform.GetComponent<PickUpKey>().mKey);

                }
                hit.transform.GetComponent<Interactable>().InteractionTriggered();
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
                interactableHUDText.text = hit.transform.gameObject.GetComponent<Interactable>().mItemName;
                InteractablePanel.gameObject.SetActive(true);
            }
        }
        else
        {
            InteractablePanel.gameObject.SetActive(false);
            interactableHUDText.text = "";
            NotesPanel.gameObject.SetActive(false);
            NotesText.text = "";
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
