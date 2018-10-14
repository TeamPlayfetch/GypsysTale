//--------------------------------------------------------------------------------------
// Purpose: TODO
//
// Description: TODO
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//--------------------------------------------------------------------------------------
// Car object. Inheriting from MonoBehaviour. The main class for the logic for the cars
// driving around the outside of the city.
//--------------------------------------------------------------------------------------
//public class Car : MonoBehaviour
//{
//    // MOVEMENT //
//    //--------------------------------------------------------------------------------------
//    // Title for this section of public values.
//    [Header("Movement:")]

//    // public float value for the car speed.
//    [LabelOverride("Speed")] [Tooltip("The speed of which the car will move in float value.")]
//    public float m_fSpeed = 40.0f;

//    // public float value for the distance a car will travel
//    [LabelOverride("Travel Distance")] [Tooltip("The distance the car will move before turning around.")]
//    public float m_fDistance = 0.0f;

//    // Leave a space in the inspector.
//    [Space]
//    //--------------------------------------------------------------------------------------

//    // PRIVATE VALUES //
//    //--------------------------------------------------------------------------------------
//    // private rigidbody.
//    private Rigidbody m_rbRigidBody;

//    // private vector3 for the move direction.
//    private Vector3 m_v3MoveDirection;
//    //--------------------------------------------------------------------------------------

//    //--------------------------------------------------------------------------------------
//    // initialization.
//    //--------------------------------------------------------------------------------------
//    void Awake()
//    {
//        // Get the rigidbody component
//        m_rbRigidBody = GetComponent<Rigidbody>();
//    }

//    //--------------------------------------------------------------------------------------
//    // Update: Function that calls each frame to update game objects.
//    //--------------------------------------------------------------------------------------
//    void Update()
//    {
//    }

//    //--------------------------------------------------------------------------------------
//    // FixedUpdate: Function that runs once, zero, or several times per frame, depending on 
//    // how many physics frames per second.
//    //--------------------------------------------------------------------------------------
//    void FixedUpdate()
//    {
//        // Run the movement function
//        Movement();
//    }

//    //--------------------------------------------------------------------------------------
//    // Movement: Move the player with in a desired direction with controller and 
//    // camera positioning.
//    //--------------------------------------------------------------------------------------
//    private void Movement()
//    {

//    }
//}