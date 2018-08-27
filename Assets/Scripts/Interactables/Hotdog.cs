//--------------------------------------------------------------------------------------
// Purpose:                                                                                         // FINISH THIS COMMENT BLOCK
//
// Description:                                                                                     // FINISH THIS COMMENT BLOCK
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// Wrapper object. Inheriting from BaseInteractable.                                                // FINISH THIS COMMENT BLOCK
//--------------------------------------------------------------------------------------
public class Hotdog : BaseInteractable
{
    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    new void Awake()
    {
        // Run the base awake
        base.Awake();
    }

    //--------------------------------------------------------------------------------------
    // InteractedWith: override function from base class for what Interactable objects do 
    // once they have been interacted with.
    //--------------------------------------------------------------------------------------
    protected override void InteractedWith()
    {
        // Run the base interactedWith function.
        base.InteractedWith();

        // Destroy Gameobjects
        Destroy(this.gameObject);
    }
}