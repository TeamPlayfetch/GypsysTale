//--------------------------------------------------------------------------------------
// Purpose: The main script for the butterfly collectable objects.
//
// Description: This script is used for the butterfly collectable, adding it to collected 
// items, destroying, etc. This script is to be attached to the butterfly object.
// prefab.
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// Butterfly object. Inheriting from BaseCollectable. The main class for the butterfly 
// collectable.
//--------------------------------------------------------------------------------------
public class Butterfly : BaseCollectable
{
    // BUTTERFLY //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Butterfly:")]

    // public bool for if the butterfly is the inital butterfly or not.
    [LabelOverride("Inital Butterfly")] [Tooltip("The first butterfly of the objective that starts the objective.")]
    public bool m_bInitalButterfly = false;
    //--------------------------------------------------------------------------------------

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
    new void Update()
    {
        // Run the base update
        base.Update();
    }
}