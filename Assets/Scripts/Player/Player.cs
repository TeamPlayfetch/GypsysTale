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
    [LabelOverride("Walking Speed")] [Tooltip("The speed of which the player will walk in float value.")]
    public float m_fWalkSpeed = 40.0f;

    // public float value for the walking speed.
    [LabelOverride("Running Speed")] [Tooltip("The speed of which the player will run in float value.")]
    public float m_fRunSpeed = 50.0f;

    // public float value for the rotation speed.
    [LabelOverride("Rotation Speed")] [Tooltip("The speed of which the player will rotation in the direction of movement.")]
    public float m_fRotationSpeed = 0.1f;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // JUMPING //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Jumping:")]

    // public float for the jumping stand height.
    [LabelOverride("Stand Height")] [Tooltip("The height to apply to the player when attempting a jump while standing.")]
    public float m_fJumpStandHeight = 4.0f;

    // public float for the jumping walk height.
    [LabelOverride("Walk Height")] [Tooltip("The height to apply to the player when attempting a jump while walking.")]
    public float m_fJumpWalkHeight = 2.3f;

    // public float for the jumping sprint height.
    [LabelOverride("Sprint Height")] [Tooltip("The height to apply to the player when attempting a jump while sprinting.")]
    public float m_fJumpSprintHeight = 1.2f;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // SPHERE CAST //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Sphere Cast:")]

    // public float for the cast radius.
    [LabelOverride("Cast Radius")] [Tooltip("The radius of the spehere cast, used for working out if the player is grounded.")]
    public float m_fCastRadius = 0.5f;

    // public float for the cast ditance.
    [LabelOverride("Cast Distance")] [Tooltip("The distance to check if the sphere cast is hitting the ground, used for working out if the player is grounded.")]
    public float m_fCastDistance = 1.15f;
    
    // public transform for the cast position.
    [LabelOverride("Cast Position Front")] [Tooltip("The position off set for the origin of the cast from the front feet.")]
    public Transform m_tCastPositionFront;

    // public transform for the cast position.
    [LabelOverride("Cast Position Back")] [Tooltip("The position off set for the origin of the cast from the back feet.")]
    public Transform m_tCastPositionBack;
    
    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // CAMERA //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Camera:")]

    // public gameobject for the main camera object of the player.
    [LabelOverride("Main Camera")] [Tooltip("The main camera object of the player.")]
    public GameObject m_gCamera;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // DEBUG //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Debug:")]

    // public bool for turning the debug info off and on.
    [LabelOverride("Display Debug Info?")] [Tooltip("Turns off and on debug information in the unity console.")]
    public bool m_bDebugMode = true;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // PUBLIC HIDDEN //
    //--------------------------------------------------------------------------------------
    // a public hidden bool for the player walking animation.
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

    // private float for the current speed of the player.
    private float m_fCurrentSpeed;

    // private float for the current jump height.
    private float m_fCurrentJumpHeight;

    // private bool for if the player is grounded
    private bool m_bIsGrounded;
    //--------------------------------------------------------------------------------------

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
        m_aniAnimator.SetBool("Running", m_bRunningAni);
        m_aniAnimator.SetBool("Jumping", m_bJumpingAni);

        // switch jumping animation off directly after playing.
        if (m_bJumpingAni == true)
            m_bJumpingAni = false;
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
        //Jumping(); // RETIRED

        // Run the interaction function
        Interaction();

        // Check if the player is grounded
        IsGrounded();
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

        // if the left controller button is not held down.
        else if (m_v3MoveDirection != Vector3.zero)
        {
            // set the current speed to running speed.
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

        // If move direction isnt zero and is grounded
        if (m_v3MoveDirection != Vector3.zero && m_bIsGrounded)
        {
            // Rotate the player to the direction it is moving
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(m_v3MoveDirection.normalized), m_fRotationSpeed);
        }

        // if the player is grounded.
        if (m_bIsGrounded)
        {
            // update the player volocity by move direction, walkspeed and deltatime.
            m_rbRigidBody.AddForce(m_v3MoveDirection * m_fCurrentSpeed, ForceMode.Acceleration);
        }
        
        // if the player is not moving or jumping make sure to stop animations.
        if (m_v3MoveDirection == Vector3.zero || !m_bIsGrounded)
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
        // If the player isnt moving
        if (m_v3MoveDirection == Vector3.zero)
        {
            // Set the current jump height to standing
            m_fCurrentJumpHeight = m_fJumpStandHeight;
        }

        // if the player is walking
        else if (m_fCurrentSpeed == m_fWalkSpeed)
        {
            // set the current jump height to walking
            m_fCurrentJumpHeight = m_fJumpWalkHeight;
        }

        // if the player is running
        else if (m_fCurrentSpeed == m_fRunSpeed)
        {
            // set the current jump height to sprinting
            m_fCurrentJumpHeight = m_fJumpSprintHeight;
        }
        
        // if space bar is pressed and the player is grounded and not falling or rising
        if ((XCI.GetButtonDown(XboxButton.A)) && m_bIsGrounded && Mathf.Abs(m_rbRigidBody.velocity.y) < 0.01f)
        {
            // play jump animation
            m_bJumpingAni = true;

            // Add force to the player to jump. // https://medium.com/ironequal/unity-character-controller-vs-rigidbody-a1e243591483
            m_rbRigidBody.AddForce(Vector3.up * Mathf.Sqrt(m_fCurrentJumpHeight * -1 * Physics.gravity.y), ForceMode.VelocityChange);
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
        // Cast a ray down from the player from front feet and back feet
        Ray rRayFront = new Ray(m_tCastPositionFront.position, Vector3.down);
        Ray rRayBack = new Ray(m_tCastPositionBack.position, Vector3.down);

        // new raycasthit for front and back feet of the player
        RaycastHit rhHitInfoFront;
        RaycastHit rhHitInfoBack;

        // Set the layermask
        int nLayerMask = LayerMask.GetMask("Ground");

        // Is the ray colliding with the ground?
        if (Physics.SphereCast(rRayFront, m_fCastRadius, out rhHitInfoFront, m_fCastDistance, nLayerMask))
        {
            // if debug for the player is turned on
            if (m_bDebugMode)
            {
                // Debug log the collider name
                Debug.Log("Grounded Front");
                Debug.Log(rhHitInfoFront.collider.gameObject.name);
                Debug.DrawRay(rRayFront.origin, Vector3.down * m_fCastDistance, Color.red);
            }

            // set grounded to true
            m_bIsGrounded = true;

            // Return true 
            return true;
        }

        // Is the ray colliding with the ground?
        if (Physics.SphereCast(rRayBack, m_fCastRadius, out rhHitInfoBack, m_fCastDistance, nLayerMask))
        {
            // if debug for the player is turned on
            if (m_bDebugMode)
            {
                // Debug log the collider name
                Debug.Log("Grounded Back");
                Debug.Log(rhHitInfoBack.collider.gameObject.name);
                Debug.DrawRay(rRayBack.origin, Vector3.down * m_fCastDistance, Color.red);
            }

            // set grounded to true
            m_bIsGrounded = true;

            // Return true 
            return true;
        }
        
        // if debug for the plauer is turned on
        if (m_bDebugMode)
        {
            // Draw the ray cast and print ray information in the console
            Debug.Log("Not Grounded");
            Debug.DrawRay(rRayFront.origin, Vector3.down * m_fCastDistance, Color.red);
            Debug.DrawRay(rRayBack.origin, Vector3.down * m_fCastDistance, Color.red);
        }

        // set grounded to false
        m_bIsGrounded = false;

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

// Possbily for improving the player. Delete if I dont use.
//https://theovermare.com/blog/2016/09/the-challenges-of-quadrupedal-characters/
//https://stackoverflow.com/questions/44396568/how-to-make-player-walk-up-hills-in-unity
//https://www.youtube.com/watch?v=Bs046-TWMhA&feature=youtu.be
//https://scialert.net/fulltextmobile/?doi=ajsr.2015.165.181