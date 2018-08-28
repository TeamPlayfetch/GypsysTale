//--------------------------------------------------------------------------------------
// Purpose: The wrapper mini-game script for the nodes.
//
// Description: This script is used for deactivating the wrapper mini-game nodes when 
// collected by the player. This script is to be attached to the node objects that are 
// to be used with the wrapper mini-game.
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// WrapperNode object. Inheriting from MonoBehaviour. wrapper node for the hotdog trail
// mini-game.
//--------------------------------------------------------------------------------------
public class WrapperNode : MonoBehaviour
{
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
            // set the gameobject inactive
            gameObject.SetActive(false);
        }
    }
}
