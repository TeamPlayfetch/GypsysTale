//--------------------------------------------------------------------------------------
// Purpose: The main player character controller.
//
// Description: This script is the main character controller for the player controlling
// the transfrom, jumping, objective interaction, etc. This script is to be attached to
// the main player object.
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using XboxCtrlrInput;
using UnityEngine;

//--------------------------------------------------------------------------------------
// Player object. Inheriting from MonoBehaviour. The main player class for player movement
//--------------------------------------------------------------------------------------
public class Player : MonoBehaviour
{
    // MOVEMENT //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Movement:")]

    // public float value for the walking speed.
    [LabelOverride("Walking Speed")]
    [Tooltip("The speed of which the player will walk in float value.")]
    public float m_fWalkSpeed = 40.0f;

    // public float value for the walking speed.
    [LabelOverride("Running Speed")]
    [Tooltip("The speed of which the player will run in float value.")]
    public float m_fRunSpeed = 50.0f;

    // public float value for the rotation speed.
    [LabelOverride("Rotation Speed")]
    [Tooltip("The speed of which the player will rotation in the direction of movement.")]
    public float m_fRotationSpeed = 0.1f;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // JUMPING //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Jumping:")]

    // public int for jumping force.
    [LabelOverride("Jump Force")]
    [Tooltip("The force to apply to the player when attempting a jump.")]
    public int m_nJumpForce = 500;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // CAMERA //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Camera:")]

    // public gameobject for the main camera object of the player.
    [LabelOverride("Main Camera")]
    [Tooltip("The main camera object of the player.")]
    public GameObject m_gCamera;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // PUBLIC HIDDEN //
    //--------------------------------------------------------------------------------------
    // a public hidden bool for the p;layer walking animation.
    [HideInInspector]
    public bool m_bWalkingAni;

    // a public hidden bool for the player running animation.
    [HideInInspector]
    public bool m_bRunningAni;

    // a public hidden bool for the player jumping animation.
    [HideInInspector]
    public bool m_bJumpingAni;
    //--------------------------------------------------------------------------------------

    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private rigidbody.
    private Rigidbody m_rbRigidBody;

    // private vector3 for the move direction.
    private Vector3 m_v3MoveDirection;

    // private animator for the player animator
    private Animator m_aniAnimator;

    // private bool for if the player can jump.
    private bool m_bJump;

    // private gameobject for the collider of the player.
    private CapsuleCollider m_cPlayerCollider;

    // private float for the current speed of the player.
    private float m_fCurrentSpeed;
    //--------------------------------------------------------------------------------------





    public float fCastRadius;

    public float fDistance;





    // DELEGATES //
    //--------------------------------------------------------------------------------------
    // Create a new Delegate for handling the interaction functions.
    public delegate void InteractionEventHandler();

    // Create an event for the delegate for extra protection. 
    public InteractionEventHandler InteractionCallback;
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    void Awake()
    {
        // Get the rigidbody component
        m_rbRigidBody = GetComponent<Rigidbody>();

        // Get the capsule collider of the player
        m_cPlayerCollider = GetComponent<CapsuleCollider>();

        // Get the animator component of the player
        m_aniAnimator = GetComponent<Animator>();

        // Set the current speed to the walk speed.
        m_fCurrentSpeed = m_fWalkSpeed;

        // set all bool for starters to false to stop animations.
        m_bWalkingAni = false;
        m_bRunningAni = false;
        m_bJumpingAni = false;
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {
        // set animation bools in the animator to the bools used in code.
        m_aniAnimator.SetBool("Walking", m_bWalkingAni);
        //m_aniAnimator.SetBool("Running", m_bRunningAni);                                                      // COMMENT BACK IN WHEN ANIMATION IS IN THE GAME
        //m_aniAnimator.SetBool("Jumping", m_bJumpingAni);

        // switch jumping animation off directly after playing.
        if (m_bJumpingAni == true)
        {
            m_bJumpingAni = false;
        }
    }

    //--------------------------------------------------------------------------------------
    // FixedUpdate: Function that runs once, zero, or several times per frame, depending on 
    // how many physics frames per second.
    //--------------------------------------------------------------------------------------
    void FixedUpdate()
    {
        // Run the movement function
        Movement();

        // run the jumping function
        Jumping();

        // Run the interaction function
        Interaction();
    }

    //--------------------------------------------------------------------------------------
    // Movement: Move the player with in a desired direction with controller and 
    // camera positioning.
    //--------------------------------------------------------------------------------------
    private void Movement()
    {
        // Get the horizontal and vertical axis
        float fHor = XCI.GetAxis(XboxAxis.LeftStickX);
        float fVer = XCI.GetAxis(XboxAxis.LeftStickY);

        // Get the camera component
        Camera sCamera = m_gCamera.GetComponent<Camera>();

        // if the left controller button is held down.
        if (XCI.GetButton(XboxButton.LeftBumper))
        {
            // set the current speed to running speed.
            m_fCurrentSpeed = m_fRunSpeed;

            // play the running animation
            m_bRunningAni = true;
        }

        // if the button is not held down.
        else
        {
            // set the current speed to the walking speed.
            m_fCurrentSpeed = m_fWalkSpeed;

            // stop the running animation
            m_bRunningAni = false;
        }

        // get the input vector
        Vector3 v3Input = new Vector3(fHor, 0.0f, fVer);

        // Apply the input vector to the camera vector
        m_v3MoveDirection = sCamera.transform.rotation * v3Input;

        // set y value to 0 and normalize the remaining vector
        m_v3MoveDirection.y = 0.0f;
        m_v3MoveDirection.Normalize();

        // If move direction isnt zero
        if (m_v3MoveDirection != Vector3.zero)
        {
            // Rotate the player to the direction it is moving
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(m_v3MoveDirection.normalized), m_fRotationSpeed);
        }

        // if the player is grounded.
        if (IsGrounded())
        {
            // update the player volocity by move direction, walkspeed and deltatime.
            m_rbRigidBody.AddForce(m_v3MoveDirection * m_fCurrentSpeed, ForceMode.Acceleration);

        }

        // if the player is not moving make sure to stop animations.
        if (m_v3MoveDirection == Vector3.zero)
        {
            m_bWalkingAni = false;
            m_bRunningAni = false;
        }

        // if the player is not running and moving then play the walk animation.
        else if (m_v3MoveDirection != Vector3.zero && !m_bRunningAni)
        {
            m_bWalkingAni = true;
        }
    }

    //--------------------------------------------------------------------------------------
    // Jumping: Checks if the jump button and if the player is grounded true and jumps the
    // player off of a marked ground.
    //--------------------------------------------------------------------------------------
    private void Jumping()
    {
        // if space bar is pressed and the player is grounded
        if ((XCI.GetButtonDown(XboxButton.A)) && IsGrounded())
        {
            // can jump bool is true
            m_bJump = true;
        }

        // Can the player jump?
        if (m_bJump)
        {
            // player cant jump
            m_bJump = false;

            // play jump animation
            m_bJumpingAni = true;

            // Add force to the player to jump
            m_rbRigidBody.AddForce(0, m_nJumpForce, 0, ForceMode.Impulse);
        }
    }

    //--------------------------------------------------------------------------------------
    // IsGrounded: Check if the player is on the ground.
    //
    // Return:
    //      bool: bool value for if the player is grounded or not.
    //--------------------------------------------------------------------------------------
    private bool IsGrounded()
    {
        // Cast a ray down from the player at the ground
        Ray rRay = new Ray(m_cPlayerCollider.transform.position, Vector3.down);
        RaycastHit rhHitInfo;

        // Set the layermask
        int nLayerMask = (LayerMask.GetMask("Ground"));

        // Is the ray colliding with the ground?
        if (Physics.SphereCast(rRay, fCastRadius, out rhHitInfo, fDistance, nLayerMask))
        {
            // Return true and debug log the collider name
            Debug.Log("Grounded");
            Debug.Log(rhHitInfo.collider.gameObject.name);
            return true;
        }

        // Draw the ray cast and print ray information in the console
        Debug.Log("Not Grounded");
        Debug.DrawRay(rRay.origin, Vector3.down * 10.0f, Color.red);
        Debug.Log("Origin: " + rRay.origin.ToString() + " /  Direction: " + rRay.direction.ToString());

        // return false if not grounded
        return false;
    }

    //--------------------------------------------------------------------------------------
    // Interaction: Function interacts on button press with interactables and other 
    // mini-game objects
    //--------------------------------------------------------------------------------------
    public void Interaction()
    {
        // If the interaction button is pressed.
        if (XCI.GetButtonDown(XboxButton.B) && InteractionCallback != null)
        {
            // Run interaction delegate.
            InteractionCallback();
        }
    }
}