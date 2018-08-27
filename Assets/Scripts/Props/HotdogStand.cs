//--------------------------------------------------------------------------------------
// Purpose:                                                                                             // FINISH THIS COMMENT BLOCK
//
// Description:                                                                                         // FINISH THIS COMMENT BLOCK
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// Wrapper object. Inheriting from BaseInteractable.                                                    // FINISH THIS COMMENT BLOCK
//--------------------------------------------------------------------------------------
public class HotdogStand : MonoBehaviour
{
    // DELEGATES //
    //--------------------------------------------------------------------------------------
    // Create a new Delegate for handling the passing of ontrigger information.
    public delegate void HotdogStandTriggerEventHandler();

    // Create an event for the delegate for extra protection. 
    public HotdogStandTriggerEventHandler HotdogStandTriggerCallback;
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // OnTriggerEnter: OnTriggerEnter is called when the Collider cObject enters the trigger.
    //
    // Param:
    //      cObject: The other Collider invloved in the collision.
    //--------------------------------------------------------------------------------------
    private void OnTriggerEnter(Collider cObject)
    {
        // if collides is player
        if (cObject.tag == "Player")
        {
            // Call the Hotdog stand trigger callback
            HotdogStandTriggerCallback();
        }
    }
}
