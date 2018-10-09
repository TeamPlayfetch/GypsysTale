//--------------------------------------------------------------------------------------
// Purpose: Manages the objective progress.
//
// Description: TODO
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    void Awake()
    {
		
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

            // reset objectives complete count.
            m_snCompletedObjectives = 0;
        }

        // if all objectives are complete
        if (m_bObjectivesComplete)
        {
            // run the ending objective of the game.
            EndingObjective();
        }
    }

    //--------------------------------------------------------------------------------------
    // EndingObjective: Function to run the final objective of the game.
    //--------------------------------------------------------------------------------------
    public void EndingObjective()
    {
        // TODO
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
