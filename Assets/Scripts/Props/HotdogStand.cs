//--------------------------------------------------------------------------------------
// Purpose: Handles what happens when the player arrives at the hotdog stand.
//
// Description: This script will check to see if the player is near the hotdog stand and
// pass that information to whatever class needs it. This script is to be attached to the 
// hot dog stand / hotdog cart object.
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// HotdogStand object. Inheriting from MonoBehaviour. Main script for the hotdog stand.
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
            if (HotdogStandTriggerCallback != null)
                HotdogStandTriggerCallback();
        }
    }
}