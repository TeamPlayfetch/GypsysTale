//--------------------------------------------------------------------------------------
// Purpose: The main script for the bone collectable objects.
//
// Description: This script is used for the bone collectable, bone animations, adding it
// to collected items, destroying, etc. This script is to be attached to the bone object
// prefab.
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// Bone object. Inheriting from MonoBehaviour. The main class for the bone collectable.
//--------------------------------------------------------------------------------------
public class Bone : MonoBehaviour
{
    // ROTATING //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Rotating:")]

    // public float value for the rotation speed
    [LabelOverride("Rotation Speed")] [Tooltip("The speed of which the bone will rotate in float value.")]
    public float m_fRotateSpeed = -80.0f;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // BOBBING //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Bobbing:")]

    // public float value for the bobbing force.
    [LabelOverride("Bobbing Force")] [Tooltip("The amount / speed the bone will bob on the spot in float value.")]
    public float m_fBobbingForce = 0.1f;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private bool for if this item has been collected by the player or not.
    private bool m_bCollected = false;

    // private float for the oringal starting postion of the bone object.
    private float m_fOriginalYPos;
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    void Awake()
    {
        // Make sure collected starts as false.
        m_bCollected = false;

        // keep hold of the original postion of the bone before bobbing.
        m_fOriginalYPos = transform.position.y;
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {
        // Rotate the bone on the y axis
        transform.Rotate(Vector3.up * m_fRotateSpeed * Time.deltaTime);

        // bobbing the bone object up and down
        transform.position = new Vector3(transform.position.x, m_fOriginalYPos + ((float)Mathf.Sin(Time.time) * m_fBobbingForce), transform.position.z);

        // has the item been collected.
        if (m_bCollected)
        {
            // Destroy the object
            Destroy(this.gameObject);
        }
    }

    //--------------------------------------------------------------------------------------
    // OnTriggerEnter: OnTriggerEnter is called when the Collider cObject enters the trigger.
    //
    // Param:
    //      cObject: The other Collider invloved in the collision.
    //--------------------------------------------------------------------------------------
    public void OnTriggerEnter(Collider cObject)
    {
        // If this object collides with the player
        if (cObject.tag == "Player")
        {
            // The item has been collected.
            m_bCollected = true;
        }
    }
}
