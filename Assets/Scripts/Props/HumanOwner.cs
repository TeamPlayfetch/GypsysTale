//--------------------------------------------------------------------------------------
// Purpose:
//
// Description: 
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
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {
		
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
