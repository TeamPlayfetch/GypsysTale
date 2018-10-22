//--------------------------------------------------------------------------------------
// Purpose: Manages the objective progress.
//
// Description: This script will manage the objective progress and activate a final 
// objective once everything is complete. This script is to be attached to the player 
// object.
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

//--------------------------------------------------------------------------------------
// ObjectiveManager object. Inheriting from MonoBehaviour. The main script for tracking
// objective progression.
//--------------------------------------------------------------------------------------
public class ObjectiveManager : MonoBehaviour
{
    // PUBLIC HIDDEN //
    //--------------------------------------------------------------------------------------
    // public static bool for currently completed objectives.
    [HideInInspector]
    public static int m_snCompletedObjectives = 0;
    //--------------------------------------------------------------------------------------

    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private bool for if all the objectives are complete.
    private bool m_bObjectivesComplete = false;
    //--------------------------------------------------------------------------------------

    // DELEGATES //
    //--------------------------------------------------------------------------------------
    // Create a new Delegate for handling the objective functions.
    public delegate void ObjectiveProgressEventHandler();

    // Create an event for the delegate for extra protection. 
    public ObjectiveProgressEventHandler ObjectiveProgressCallback;
    //--------------------------------------------------------------------------------------








    public PostProcessingProfile m_pppAfternoon;



    public PostProcessingProfile m_pppEvening;



    public GameObject m_gCamera;



    public GameObject m_gDemoComplete;







    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    private void Awake()
    {
        // set Temp demo screen to inactive.
        m_gDemoComplete.SetActive(false);
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {
        // if objectives are not all complete
        if (!m_bObjectivesComplete)
        {
            // Run the objective progress check script
            ObjectiveProgress();

            // get the amount of subbed functions in the delegate.
            int nSubbedFuncs = ObjectiveProgressCallback.GetInvocationList().Length;

            // If completed objectives is the same as subbed functions then objectives are all complete. 
            if (m_snCompletedObjectives == nSubbedFuncs)
                m_bObjectivesComplete = true;

            // Cycle the day post processing profile
            DayCycle();
        }

        // if all objectives are complete
        if (m_bObjectivesComplete)
        {
            // run the ending objective of the game.
            EndingObjective();
        }
    }

    //--------------------------------------------------------------------------------------
    // DayCycle: Switch the camera post processing behaviour profile for the different times
    // of day.
    //--------------------------------------------------------------------------------------
    private void DayCycle()
    {
        // if 3 of 6 objectives are complete
        if (m_snCompletedObjectives == 3)
        {
            // switch the camera profile
            m_gCamera.GetComponent<PostProcessingBehaviour>().profile = m_pppAfternoon;
        }

        // if 6 of 6 objectives are completet
        if (m_snCompletedObjectives == 6)
        {
            // switch the camera profile
            m_gCamera.GetComponent<PostProcessingBehaviour>().profile = m_pppEvening;
        }
    }

    //--------------------------------------------------------------------------------------
    // EndingObjective: Function to run the final objective of the game.
    //--------------------------------------------------------------------------------------
    private void EndingObjective()
    {
        // Set temp demo screen to active
        m_gDemoComplete.SetActive(true);
    }

    //--------------------------------------------------------------------------------------
    // ObjectiveProgress: Function to check the progress of all objectives.
    //--------------------------------------------------------------------------------------
    public void ObjectiveProgress()
    {
        // Run objective progress delegate.
        ObjectiveProgressCallback();
    }
}
