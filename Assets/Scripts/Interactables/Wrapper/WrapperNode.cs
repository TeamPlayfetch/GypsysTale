//--------------------------------------------------------------------------------------
// Purpose: 
//
// Description:                                                                                 // FINISH THIS COMMENT BLOCK
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// WrapperNode object. Inheriting from MonoBehaviour.                                           // FINISH THIS COMMENT BLOCK
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
