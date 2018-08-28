//--------------------------------------------------------------------------------------
// Purpose: The main script for the bone collectable objects.
//
// Description: This script is used for the bone collectable, bone animations, adding it
// to collected items, destroying, etc. This script is to be attached to the bone object
// prefab.
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// Bone object. Inheriting from BaseCollectable. The main class for the bone collectable.
//--------------------------------------------------------------------------------------
public class Bone : BaseCollectable
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
    new void Update()
    {
        // Run the base update
        base.Update();
    }
}
