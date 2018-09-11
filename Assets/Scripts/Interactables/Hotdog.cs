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
    // PARTICLES //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("PARTICLES:")]

    // public particle system for eating visual.
    [LabelOverride("Eating Particle")] [Tooltip("Particle System for when the dog is eating the hotdog.")]
    public ParticleSystem m_psEatingParticle;
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
    void Update()
    {
        // Destroy Gameobjects if the particle isn't playing and has been interacted with
        if (!m_psEatingParticle.isPlaying && m_bInteracted)
            Destroy(this.gameObject);
    }

    //--------------------------------------------------------------------------------------
    // InteractedWith: override function from base class for what Interactable objects do 
    // once they have been interacted with.
    //--------------------------------------------------------------------------------------
    protected override void InteractedWith()
    {
        // Run the base interactedWith function.
        base.InteractedWith();

        // Enable the particle system for eating visual
        m_psEatingParticle.Play();
    }
}