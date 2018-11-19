//--------------------------------------------------------------------------------------
// Purpose: Runs the final logic for end game.
//
// Description: This script holds the main logic for the owner object. Attach to the 
// owner object.
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// HumanOwner object. Inheriting from MonoBehaviour. Main script for the Human Owner.
//--------------------------------------------------------------------------------------
public class HumanOwner : MonoBehaviour
{
    // public gameobject for the credits object
    [LabelOverride("Credits Object")] [Tooltip("The gameobject to activate when the creidts is to start playing.")]
    public GameObject m_gCreditsObject;

    // private swap camera value for swaping the camera
    private SwapCamera m_gSwapCamera;

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    void Awake()
    {
        // get swap camera component
        m_gSwapCamera = GetComponent<SwapCamera>();
    }

    //--------------------------------------------------------------------------------------
    // OnTriggerEnter: OnTriggerEnter is called when the Collider cObject enters the trigger.
    //
    // Param:
    //      cObject: The other Collider invloved in the collision.
    //--------------------------------------------------------------------------------------
    private void OnTriggerEnter(Collider cObject)
    {
        // if collides is lost child
        if (cObject.tag == "Player")
        {
            // activate the credits object
            m_gCreditsObject.SetActive(true);

            // set the camera to show owner
            m_gSwapCamera.m_bInteracted = true;
        }
    }
}
