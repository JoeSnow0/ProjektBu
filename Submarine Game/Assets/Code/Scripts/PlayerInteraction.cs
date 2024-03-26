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
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask interactableMask;
    [SerializeField] TextMeshProUGUI interactableHUDText;
    Vector3 origin;
    Vector3 direction;
    bool mInteractInput;

    private void Start()
    {
        interactableHUDText.text = "";
    }
    public void InteractInput(InputAction.CallbackContext context)
    {
        //Get the input from the assigned Input from the Player Input
        mInteractInput = false;
        mInteractInput = context.action.WasPressedThisFrame();
        //Debug.Log("Look Input: " + mInteractInput);
    }
    RaycastHit CheckInteractable()
    {
        origin = mCam.transform.position;
        direction = mCam.transform.forward;
        RaycastHit hit;
        Physics.Raycast(origin, direction, out hit, maxDistance, interactableMask, queryTriggerInteraction: QueryTriggerInteraction.Ignore);
        return hit;
        
    }
    void AttemptInteraction()
    {
        if(mInteractInput)
        {
            RaycastHit hit = CheckInteractable();
            if (hit.collider != null)
            {
                hit.transform.GetComponent<Interactable>().InteractionTriggered();
            }
        }
    }
    void UpdateHUD()
    {
        RaycastHit hit = CheckInteractable();
        interactableHUDText.text = "";
        if(hit.collider != null)
        {
            interactableHUDText.text = hit.transform.gameObject.GetComponent<Interactable>().mItemName;
        }
    }
    private void Update()
    {
        UpdateHUD();
        AttemptInteraction();
    }
    private void LateUpdate()
    {
        mInteractInput = false;
    }
}
