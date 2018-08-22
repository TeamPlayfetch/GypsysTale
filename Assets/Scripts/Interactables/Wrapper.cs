//--------------------------------------------------------------------------------------
// Purpose: The wrapper script for hot dog trail mini-game.
//
// Description: This script is used for the hot dog wrapper object. This script is to be 
// attached to the hot dog wrapper object.
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// Wrapper object. Inheriting from BaseInteractable. Main class for the hot dog wrapper 
// used for particle trail mini game / objective.
//--------------------------------------------------------------------------------------
public class Wrapper : BaseInteractable
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
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {
    }

    //--------------------------------------------------------------------------------------
    // InteractedWith: override function from base class for what Interactable objects do 
    // once they have been interacted with.
    //--------------------------------------------------------------------------------------
    protected override void InteractedWith()
    {
        // Display debug message showing interaction.
        Debug.Log("Interacted");
    }
}
