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
    // ACTIVE INDICATOR //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Active Indicator:")]

    // public gameobject for the active particles of the collectable
    [LabelOverride("Active Particle")] [Tooltip("The gameobject used for displaying the particles when the bone is currently active.")]
    public GameObject m_gActiveParticle;
    
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
        // has the item been collected.
        if (m_bCollected)
        {
            // New array of particles
            ParticleSystem[] apsParticles = m_gActiveParticle.GetComponentsInChildren<ParticleSystem>();

            // for each particle in the array
            for (int i = 0; i < apsParticles.Length; i++)
            {
                // destory particles
                Destroy(apsParticles[i]);
            }
        }

        // Run the base update
        base.Update();
    }
}