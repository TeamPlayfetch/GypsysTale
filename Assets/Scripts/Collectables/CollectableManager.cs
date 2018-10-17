//--------------------------------------------------------------------------------------
// Purpose: The manager of all player collectables.
//
// Description: This script is the main manager of all collectables for the player
// This script is to be attached to the main player controller with the player script.
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//--------------------------------------------------------------------------------------
// CollectableManager object. Inheriting from MonoBehaviour. The main class to take care 
// of the player collectables.
//--------------------------------------------------------------------------------------
public class CollectableManager : MonoBehaviour
{
    // BONE //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Bones:")]
    
    // public float value for the bone UI object.
    [LabelOverride("Bone UI Object")] [Tooltip("The UI object that the bone score is shown with. ")]
    public GameObject m_gBoneUI;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // GENERAL UI //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("General UI:")]

    // public float value for the total timer amount
    [LabelOverride("Timer Amount")] [Tooltip("The amount of time that the UI will appear for when a collectable is picked up.")]
    public float m_fUITimerAmount = 3;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private bool for if the bone item has been collected by the player or not.
    private bool m_bBoneCollected = false;

    // private int for the current bone score.
    private int m_nBoneScore = 0;

    // private float for the UI timer.
    private float m_fUITimer = 0;

    // private objectivemanager object for getting the objective manager script.
    private ObjectiveManager m_sObjectiveManager;

    // private bool for if the objective is complete
    private bool m_bObjectiveComplete = false;

    // private int for the amount of bones to collect
    private int m_nBoneTotal = 42;
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    void Awake()
    {
        // Get all the bones in the scene
        GameObject[] agBones = GameObject.FindGameObjectsWithTag("Bone");

        // set the total bones to the bones array length
        m_nBoneTotal = agBones.Length;

        // set the array back to null
        agBones = null;

        // Make sure collectedbone starts as false.
        m_bBoneCollected = false;

        // make sure timer starts at 0
        m_fUITimer = 0;

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
        // Update UI timer.
        m_fUITimer -= Time.deltaTime;

        // Run the bone function.
        BonePickup();

        // if bone collected hits total needed
        if (m_nBoneScore == m_nBoneTotal)
        {
            // set objective complete to true.
            m_bObjectiveComplete = true;
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
    // OnTriggerEnter: OnTriggerEnter is called when the Collider cObject enters the trigger.
    //
    // Param:
    //      cObject: The other Collider invloved in the collision.
    //--------------------------------------------------------------------------------------
    public void OnTriggerEnter(Collider cObject)
    {
        // if the bone collectable has been collided with
        if (cObject.tag == "Bone")
        {
            // The bone item has been collected.
            m_bBoneCollected = true;
        }
    }

    //--------------------------------------------------------------------------------------
    // Bone: The bone collectable logic for the object score and UI.
    //--------------------------------------------------------------------------------------
    private void BonePickup()
    {
        // if a bone has been collected.
        if (m_bBoneCollected)
        {
            // Increase the bone score by one.
            m_nBoneScore += 1;

            // Activate the BoneUI
            m_gBoneUI.SetActive(true);

            // Reset timer for seting bone ui active
            m_fUITimer = m_fUITimerAmount;

            // Bone collection has been complete.
            m_bBoneCollected = false;
        }

        // if the timer is under 0.
        if (m_fUITimer <= 0)
        {
            // Set boneUI active to false.
            m_gBoneUI.SetActive(false);
        }

        // Update the BoneUI text to show current bone score.
        m_gBoneUI.GetComponentInChildren<Text>().text = m_nBoneScore.ToString() + "/" + m_nBoneTotal.ToString();
    }
}
