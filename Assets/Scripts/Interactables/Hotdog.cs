//--------------------------------------------------------------------------------------
// Purpose: Interaction logic for the hotdog object.
//
// Description: This script will take care of the logic when a hotdog is interacted with
// by the player. This script is to be attached to the hotdog object.
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// Hotdog object. Inheriting from BaseInteractable. The hotdog interactable object.
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