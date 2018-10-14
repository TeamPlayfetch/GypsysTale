//--------------------------------------------------------------------------------------
// Purpose: TODO
//
// Description: TODO
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// Car object. Inheriting from MonoBehaviour. The main class for the logic for the cars
// driving around the outside of the city.
//--------------------------------------------------------------------------------------
public class Car : MonoBehaviour
{
    // MOVEMENT //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Movement:")]

    // public float value for the car speed.
    [LabelOverride("Speed")] [Tooltip("The speed of which the car will move in float value.")]
    public float m_fSpeed = 40.0f;

    // public float value for the distance a car will travel
    [LabelOverride("Travel Distance")] [Tooltip("The distance the car will move before turning around.")]
    public float m_fDistance = 0.0f;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private rigidbody.
    private Rigidbody m_rbRigidBody;

    // private vector3 for the move direction.
    private Vector3 m_v3MoveDirection;
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    void Awake()
    {
        // Get the rigidbody component
        m_rbRigidBody = GetComponent<Rigidbody>();
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {
    }

    //--------------------------------------------------------------------------------------
    // FixedUpdate: Function that runs once, zero, or several times per frame, depending on 
    // how many physics frames per second.
    //--------------------------------------------------------------------------------------
    void FixedUpdate()
    {
        // Run the movement function
        Movement();
    }

    //--------------------------------------------------------------------------------------
    // Movement: Move the player with in a desired direction with controller and 
    // camera positioning.
    //--------------------------------------------------------------------------------------
    private void Movement()
    {
    //    // Get the horizontal and vertical axis
    //    float fHor = XCI.GetAxis(XboxAxis.LeftStickX);
    //    float fVer = XCI.GetAxis(XboxAxis.LeftStickY);

    //    // Get the camera component
    //    Camera sCamera = m_gCamera.GetComponent<Camera>();

    //    // if the left controller button is held down.
    //    if (XCI.GetButton(XboxButton.LeftBumper))
    //    {
    //        // set the current speed to running speed.
    //        m_fCurrentSpeed = m_fRunSpeed;

    //        // play the running animation
    //        m_bRunningAni = true;
    //    }

    //    // if the button is not held down the player is still moving
    //    else if (m_v3MoveDirection != Vector3.zero)
    //    {
    //        // set the current speed to the walking speed.
    //        m_fCurrentSpeed = m_fWalkSpeed;

    //        // stop the running animation
    //        m_bRunningAni = false;
    //    }

    //    // get the input vector
    //    Vector3 v3Input = new Vector3(fHor, 0.0f, fVer);

    //    // Apply the input vector to the camera vector
    //    m_v3MoveDirection = sCamera.transform.rotation * v3Input;

    //    // set y value to 0 and normalize the remaining vector
    //    m_v3MoveDirection.y = 0.0f;
    //    m_v3MoveDirection.Normalize();

    //    // If move direction isnt zero and is grounded
    //    if (m_v3MoveDirection != Vector3.zero && m_bIsGrounded)
    //    {
    //        // Rotate the player to the direction it is moving
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(m_v3MoveDirection.normalized), m_fRotationSpeed);
    //    }

    //    // if the player is grounded.
    //    if (m_bIsGrounded)
    //    {
    //        // update the player volocity by move direction, walkspeed and deltatime.
    //        m_rbRigidBody.AddForce(m_v3MoveDirection * m_fCurrentSpeed, ForceMode.Acceleration);
    //    }

    //    // if the player is not moving or jumping make sure to stop animations.
    //    if (m_v3MoveDirection == Vector3.zero || !m_bIsGrounded)
    //    {
    //        m_bWalkingAni = false;
    //        m_bRunningAni = false;
    //    }

    //    // if the player is not running and moving then play the walk animation.
    //    else if (m_v3MoveDirection != Vector3.zero && !m_bRunningAni)
    //    {
    //        m_bWalkingAni = true;
    //    }
    }
}