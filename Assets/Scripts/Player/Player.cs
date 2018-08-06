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
    public float m_fWalkSpeed = 20.0f;

    // public float value for the walking speed.
    [LabelOverride("Running Speed")] [Tooltip("The speed of which the player will run in float value.")]
    public float m_fRunSpeed = 30.0f;

    // Leave a space in the inspector
    [Space]
    //--------------------------------------------------------------------------------------

    // JUMPING //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Jumping:")]

    // public int for jumping force
    [LabelOverride("Jump Force")] [Tooltip("The force to apply to the player when attempting a jump.")]
    public int m_nJumpForce = 500;

    // Leave a space in the inspector
    [Space]
    //--------------------------------------------------------------------------------------

    // Camera //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Camera:")]

    // public gameobject for the main camera object of the player
    [LabelOverride("Main Camera")] [Tooltip("The main camera object of the player.")]
    public GameObject m_gCamera;

    // Leave a space in the inspector
    [Space]
    //--------------------------------------------------------------------------------------

    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private rigidbody
    private Rigidbody m_rbRigidBody;

    // private vector3 for the move direction
    private Vector3 m_v3MoveDirection;

    // private bool for if the player can jump
    private bool m_bJump;

    // private gameobject for the collider of the player
    private CapsuleCollider m_cPlayerCollider;
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
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {
        // Get the horizontal and vertical axis
        float fHor = Input.GetAxis("Horizontal");
        float fVer = Input.GetAxis("Vertical");

        // Get the camera component
        Camera sCamera = m_gCamera.GetComponent<Camera>();

        // get the input vector
        Vector3 v3Input = new Vector3(fHor, 0.0f, fVer);

        // Apply the input vector to the camera vector
        m_v3MoveDirection = sCamera.transform.rotation * v3Input;

        // set y value to 0 and normalize the remaining vector
        m_v3MoveDirection.y = 0.0f;
        m_v3MoveDirection.Normalize();
        






        // Rotate the player to the direction it is moving







        // if space bar is pressed and the player is grounded
        if (Input.GetKeyUp(KeyCode.Space) && IsGrounded())
        {
            // can jump bool is true
            m_bJump = true;
        }
    }

    //--------------------------------------------------------------------------------------
    // FixedUpdate: 
    //--------------------------------------------------------------------------------------
    void FixedUpdate()
    {
        // Run the movement function
        Movement();

        // Can the player jump?
        if (m_bJump)
        {
            // player cant jump
            m_bJump = false;

            // Add force to the player to jump
            m_rbRigidBody.AddForce(0, m_nJumpForce, 0, ForceMode.Impulse);
        }
    }

    //--------------------------------------------------------------------------------------
    // Movement: 
    //--------------------------------------------------------------------------------------
    void Movement()
    {
        // update the player volocity by move direction, walkspeed and deltatime.
        m_rbRigidBody.AddForce(m_v3MoveDirection * m_fWalkSpeed, ForceMode.Acceleration);
    }

    //--------------------------------------------------------------------------------------
    // IsGrounded: Check if the player is on the ground.
    //
    // Return:
    //      bool: bool value for if the player is grounded or not.
    //--------------------------------------------------------------------------------------
    bool IsGrounded()
    {
        // Cast a ray down from the player at the ground
        Debug.Log("IsGrounded");
        Ray rRay = new Ray(transform.position - new Vector3(0, m_cPlayerCollider.height * 0.4f, 0), Vector3.down);
        RaycastHit rhHitInfo;

        // Set the layermask
        int nLayerMask = (LayerMask.GetMask("Ground"));

        // Is the ray colliding with the ground?
        if (Physics.Raycast(rRay, out rhHitInfo, 0.5f, nLayerMask))
        {
            // Return true and debug log the collider name
            Debug.Log(rhHitInfo.collider.name);
            return true;
        }

        // Draw the ray cast and print ray information in the console
        Debug.DrawRay(rRay.origin, Vector3.down);
        Debug.Log(rRay.origin.ToString() + " " + rRay.direction.ToString());

        // return false if not grounded
        return false;
    }
}