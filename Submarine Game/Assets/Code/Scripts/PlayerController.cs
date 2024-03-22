using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Internal Refs
    [Header("Character References")]
    [Header("Internal References (assigned before start)")]
    [SerializeField] GameObject mHead;
    [SerializeField] GameObject mBody;
    [SerializeField] CapsuleCollider mBodyCollider;
    [SerializeField] Rigidbody mRigidbody;
    [SerializeField] Camera mCam;

    //External Refs


    //Variables
    [Header("Character Settings")]
    [Range(0f, 3f)]
    [Tooltip("In Meters, adjusts the height of the player")]
    [SerializeField] float height;
    
    [Range(0f, 3f)]
    [Tooltip("In Meters, adjusts the height of the player when crouched")]
    [SerializeField] float crouchHeight;

    [Range(0f, 3f)]
    [Tooltip("Crouch Speed, how fast the player will be walking while crouched down")]
    [SerializeField] float crouchSpeed;

    [Range(0f, 3f)] 
    [Tooltip("In Meters, the width of the player (is applied to the width of the collider)")]
    [SerializeField] float width;
    
    [Range(0f, 1000f)]
    [Tooltip("Regular walking speed")]
    [SerializeField] float movementSpeed;
    
    [Range(0f, 1000f)]
    [Tooltip("sprint speed")]
    [SerializeField] float sprintSpeed;
    
    [Range(0f, 100f)]
    [Tooltip("Speed of your turning, also affected by mouse sensitivity")]
    [SerializeField] float turnSpeed;
    
    [Range(-180f, 180f)]
    [Tooltip("Keep within reasonable head tilting range for a human")]
    [SerializeField] float headTiltMax = 175f;
    [Range(-180f, 180f)]
    [Tooltip("Keep within reasonable head tilting range for a human")]
    [SerializeField] float headTiltMin = 5f;
    [Range(45f, 200f)]
    [Tooltip("Average 60-100 depending on if you're playing on a console or PC, AFFECTS MOTION SICKNESS")]
    [SerializeField] float fieldOfView = 90f;

    //Input
    Vector2 mMoveInput; 
    Vector2 mLookInput;
    //Used for turning
    float xRotation = 0f;
    float yRotation = 0f;

    private void Start()
    {
        InitializePlayer();

    }
    void InitializePlayer()
    {
        //Anything that needs to be set at start goes here, call it again if player needs to be reinitialized
        mCam.fieldOfView = fieldOfView;
        Cursor.lockState = CursorLockMode.Locked;
        //mBodyCollider.height = height;
        SetPlayerHeight(height);
        mBodyCollider.radius = width;
        //Adjust the position of the head to be at the top of the collider
            //mHead.transform.localPosition = new Vector3(0f, mBodyCollider.height * 0.5f - mHead.transform.localScale.y * 0.5f, 0f);
    }

    void SetPlayerHeight(float newHeight)
    {
        mBodyCollider.height = newHeight;
        //Adjust the position of the head to be at the top of the collider
        mHead.transform.localPosition = new Vector3(0f, mBodyCollider.height * 0.5f - mHead.transform.localScale.y * 0.5f, 0f);
    }
    public void MoveInput(InputAction.CallbackContext context)
    {
        //Get the input from the assigned Input from the Player Input
        mMoveInput = context.action.ReadValue<Vector2>();
        Debug.Log("Move Input: " + mMoveInput);
    }
    public void LookInput(InputAction.CallbackContext context)
    { 
        //Get the input from the assigned Input from the Player Input
        mLookInput = context.action.ReadValue<Vector2>();
        Debug.Log("Look Input: " +  mLookInput);
    }
    void Movement()
    {
        //Move forward in the direction the player body is facing
        Vector3 move = transform.right * mMoveInput.x + transform.forward * mMoveInput.y;
        mRigidbody.MovePosition(mRigidbody.position + move * movementSpeed * Time.deltaTime);
    }
    void Look()
    {
        //combine input, speed and delta time for accurate turning at any FPS
        Vector2 addRotation = Time.deltaTime * turnSpeed * mLookInput;

        //Head rotation v - ^
        xRotation -= addRotation.y;
        xRotation = Mathf.Clamp(xRotation, headTiltMin, headTiltMax); 
        mHead.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //Body Rotation < - >
        yRotation += addRotation.x;
        transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }

    void crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) 
        {
            //transform.localScale = new Vector3(transform.localScale.x, crouchHeight);

            //transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);

            SetPlayerHeight(crouchHeight);
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            //transform.localScale = new Vector3(transform.localScale.x, crouchHeight);
            //transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f);
            SetPlayerHeight(height);
        }
    }
    private void Update()
    {
        Look();
        crouch();
    }
    private void FixedUpdate()
    {
        //Movement is processed in fixed updates so it lines up with the physics checks
        Movement();

        
    }
}
