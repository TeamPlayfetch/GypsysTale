//--------------------------------------------------------------------------------------
// Purpose: Interaction logic for the lost child object.
//
// Description: 
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// LostChild object. Inheriting from BaseInteractable. The LostChild interactable object.
//--------------------------------------------------------------------------------------
public class LostChild : BaseInteractable
{






    public GameObject m_gParentObject;

    public Transform m_gNewTarget;

    public AudioClip m_acCompleteAudio;




    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private objectivemanager object for getting the objective manager script.
    private ObjectiveManager m_sObjectiveManager;

    // private bool for if the objective is complete
    private bool m_bObjectiveComplete = false;

    // private bool for if the objectve is complete.
    private bool m_bMarkComplete = false;

    // the AIseek script attached to this object
    private SeekAI m_sSeekScript;

    // private swap camera value for swaping the camera
    private SwapCamera m_gSwapCamera;

    // private bool for when to fade out the mesh
    private bool m_bFadeOut = false;
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

        // get the component for the seek script
        m_sSeekScript = GetComponent<SeekAI>();

        // get swap camera component
        m_gSwapCamera = GetComponent<SwapCamera>();

        // get the audiosource component of the interactable object
        if (!m_bInteractAudio)
        m_asAudioSource = GetComponent<AudioSource>();
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {
        // if the parent is not null
        if (m_gParentObject != null)
        {
            // Check if the child has triggered the parent collison box.
            if (m_gParentObject.GetComponent<HumanParent>().m_bChildReturned)
            {
                // set objective complete to true.
                m_bObjectiveComplete = true;

                // switch navmesh target to end target
                m_sSeekScript.m_tGoal = m_gNewTarget;
            }
        }

        else
        {
            // start the fade out of the mesh
            m_bFadeOut = true;
        }

        // start fade out for material
        if (m_bFadeOut)
        {
            // destroy the gameobject
            Destroy(gameObject);
        }
    }

    //--------------------------------------------------------------------------------------
    // ObjectiveProgress: Function that checks the progress of the objective.
    //--------------------------------------------------------------------------------------
    private void ObjectiveProgress()
    {
        // if the objective is complete add to static completed objectives int
        if (m_bObjectiveComplete && !m_bMarkComplete)
        {
            ObjectiveManager.m_snCompletedObjectives += 1;
            m_bMarkComplete = true;

            // play audio on complete of the objective
            m_asAudioSource.PlayOneShot(m_acCompleteAudio);
        }
    }

    //--------------------------------------------------------------------------------------
    // InteractedWith: override function from base class for what Interactable objects do 
    // once they have been interacted with.
    //--------------------------------------------------------------------------------------
    protected override void InteractedWith()
    {
        // Run the base interactedWith function.
        base.InteractedWith();

        // set the camera to show parent
        m_gSwapCamera.m_bInteracted = true;

        // enabled the seek script for the AI
        m_sSeekScript.enabled = true;
    }
}