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

    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private objectivemanager object for getting the objective manager script.
    private ObjectiveManager m_sObjectiveManager;

    // private bool for if the objective is complete
    private bool m_bObjectiveComplete = false;
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    new void Awake()
    {
        // Run the base awake
        base.Awake();

        // Set the ObjectiveManager script object to the ObjectiveManager script.
        m_sObjectiveManager = GameObject.Find("Player").GetComponent<ObjectiveManager>();

        // Subscribe the function ObjectiveProgress with the ObjectiveProgressCallback delegate event
        m_sObjectiveManager.ObjectiveProgressCallback += ObjectiveProgress;
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {
        // if the particle isn't playing and has been interacted with
        if (!m_psEatingParticle.isPlaying && m_bInteracted)
        {
            // set objective complete to true.
            m_bObjectiveComplete = true;

            // destroy gameobject.
            Destroy(this.gameObject);
        }
    }

    //--------------------------------------------------------------------------------------
    // ObjectiveProgress: Function that checks the progress of the objective.
    //--------------------------------------------------------------------------------------
    private void ObjectiveProgress()
    {
        // if the objective is complete add to static completed objectives int
        if (m_bObjectiveComplete)
            ObjectiveManager.m_snCompletedObjectives += 1;
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