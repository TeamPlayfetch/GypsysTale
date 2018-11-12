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

    // public particle system for bone winning particle.
    [LabelOverride("Win Particle")] [Tooltip("The particle to play when the objective is complete.")]
    public ParticleSystem m_psBoneWinParticle;

    // public audio clip for bone winning audio.
    [LabelOverride("Win Audio")] [Tooltip("The audio to play when the objective is complete.")]
    public AudioClip m_acBoneWinAudio;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // BUTTERFLY //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Butterflies:")]

    // public particle system for butterfly winning particle.
    [LabelOverride("Win Particle")][Tooltip("The particle to play when the objective is complete.")]
    public ParticleSystem m_psButterflyWinParticle;

    // public audio clip for butterfly winning audio.
    [LabelOverride("Win Audio")] [Tooltip("The audio to play when the objective is complete.")]
    public AudioClip m_acButterflyWinAudio;

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

    // private int for the amount of bones to collect
    private int m_nBoneTotal = 42;

    // private bool for if the bone objective is complete.
    private bool m_bBoneComplete = false;

    // private array of gameobjects for the butterfly objects
    private GameObject[] m_agButterflies;

    // private bool for if the butterly item has been collected by the player or not.
    private bool m_bButterflyCollected = false;

    // private int for the current butterfly score.
    private int m_nButterflyScore = 0;

    // private int for the amount of butterflies to collect
    private int m_nButterflyTotal = 8;

    // private bool for if the butterfly objective is complete.
    private bool m_bButterflyComplete = false;

    // private bool for if butterfly objective has started.
    private bool m_bStartButterfly = false;

    // private float for the UI timer.
    private float m_fUITimer = 0;

    // private objectivemanager object for getting the objective manager script.
    private ObjectiveManager m_sObjectiveManager;

    // private bool for if the objective is complete
    private bool m_bObjectiveComplete = false;

    // private bool for if the objectve is complete.
    private bool m_bMarkCompleteButterfly = false;

    // private bool for if the objectve is complete.
    private bool m_bMarkCompleteBone = false;

    // private audio source
    protected AudioSource m_asAudioSource;
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    void Awake()
    {
        // get the audiosource component
        m_asAudioSource = GetComponent<AudioSource>();

        // Get all the bones in the scene
        GameObject[] agBones = GameObject.FindGameObjectsWithTag("Bone");

        // set the total bones to the bones array length
        m_nBoneTotal = agBones.Length;

        // set the array back to null
        agBones = null;

        // Make sure collectedbone starts as false.
        m_bBoneCollected = false;

        // Get all the butterflies in the scene
        m_agButterflies = GameObject.FindGameObjectsWithTag("Butterfly");

        // set the total butterflies to the butterflies array length
        m_nButterflyTotal = m_agButterflies.Length;

        // Make sure collectedbutterfly starts as false.
        m_bButterflyCollected = false;
        
        // loop through each butterfly
        for (int i = 0; i < m_agButterflies.Length; i++)
        {
            // set active to false for each butterfly that is not the inital butterfly.
            if (!m_agButterflies[i].gameObject.GetComponent<Butterfly>().m_bInitalButterfly)
                m_agButterflies[i].SetActive(false);
        }

        // make sure timer starts at 0
        m_fUITimer = 0;

        // Set the ObjectiveManager script object to the ObjectiveManager script.
        m_sObjectiveManager = GameObject.Find("Player").GetComponent<ObjectiveManager>();

        // Subscribe the function ObjectiveProgress with the ObjectiveProgressCallback delegate event
        m_sObjectiveManager.ObjectiveProgressCallback += ObjectiveProgressButterfly;
        m_sObjectiveManager.ObjectiveProgressCallback += ObjectiveProgressBone;
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {
        // Update UI timer.
        m_fUITimer -= Time.deltaTime;

        // Run the logic of each collectable.
        BoneManager();
        ButterflyManager();
    }

    //--------------------------------------------------------------------------------------
    // ObjectiveProgress: Function that checks the progress of the objective.
    //--------------------------------------------------------------------------------------
    private void ObjectiveProgressBone()
    {
        // if the objective is complete add to static completed objectives int
        if (m_bBoneComplete && !m_bMarkCompleteBone)
        {
            ObjectiveManager.m_snCompletedObjectives += 1;
            m_bMarkCompleteBone = true;
        }
    }

    //--------------------------------------------------------------------------------------
    // ObjectiveProgress: Function that checks the progress of the objective.
    //--------------------------------------------------------------------------------------
    private void ObjectiveProgressButterfly()
    {
        // if the objective is complete add to static completed objectives int
        if (m_bButterflyComplete && !m_bMarkCompleteButterfly)
        {
            ObjectiveManager.m_snCompletedObjectives += 1;
            m_bMarkCompleteButterfly = true;
        }
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

        // if the butterfly collectable has been collided with
        if (cObject.tag == "Butterfly")
        {
            // The butterfly item has been collected.
            m_bButterflyCollected = true;
        }
    }

    //--------------------------------------------------------------------------------------
    // BoneManager: Manages the bone objective.
    //--------------------------------------------------------------------------------------
    private void BoneManager()
    {
        // Run the pickup function.
        BonePickup();

        // if bone collected hits total needed
        if (m_nBoneScore == m_nBoneTotal && !m_bBoneComplete)
        {
            // Play winning audio for the bone objective.
            m_asAudioSource.PlayOneShot(m_acButterflyWinAudio);

            // Play winning particle for the bone objective.
            Instantiate(m_psBoneWinParticle, transform.position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);

            // set objective complete to true.
            m_bBoneComplete = true;
        }
    }

    //--------------------------------------------------------------------------------------
    // BonePickup: The bone collectable logic for the object score and UI.
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

    //--------------------------------------------------------------------------------------
    // ButterflyManager: Manages the butterfly objective.
    //--------------------------------------------------------------------------------------
    private void ButterflyManager()
    {
        // Run the pickup function.
        ButterflyPickup();
        
        // if butterfly collected hits total needed
        if (m_nButterflyScore == m_nButterflyTotal && !m_bButterflyComplete)
        {
            // Play winning audio for the butterfly objective.
            m_asAudioSource.PlayOneShot(m_acButterflyWinAudio);

            // play winning particle for the butterfly objective.
            Instantiate(m_psButterflyWinParticle, transform.position + new Vector3(0.0f,1.0f,0.0f), Quaternion.identity);

            // set objective complete to true.
            m_bButterflyComplete = true;
        }
    }

    //--------------------------------------------------------------------------------------
    // ButterflyPickup: The Butterfly collectable logic for the object score.
    //--------------------------------------------------------------------------------------
    private void ButterflyPickup()
    {
        // if a butterfly has been collected.
        if (m_bButterflyCollected)
        {
            // Increase the butterfly score by one.
            m_nButterflyScore += 1;

            // Butterfly collection has been complete.
            m_bButterflyCollected = false;
            
            // Start the objective
            if (!m_bStartButterfly)
                ButterflyStartUp();
            
            // loop through each butterfly
            for (int i = 0; i < m_agButterflies.Length; i++)
            {
                // check if each butterfly is null
                if (m_agButterflies[i] != null)
                {
                    // if not the inital butterfly increase the pitch of the audio
                    if (!m_agButterflies[i].gameObject.GetComponent<Butterfly>().m_bInitalButterfly)
                        m_agButterflies[i].gameObject.GetComponent<Butterfly>().m_asAudioSource.pitch += 0.2f;
                }
            }
        }
    }

    //--------------------------------------------------------------------------------------
    // ButterflyStartUp: Starts the butterfly objective.
    //--------------------------------------------------------------------------------------
    private void ButterflyStartUp()
    {
        // new bool for if the objective has started or not
        bool bStart = false;

        // loop through each butterfly
        for (int i = 0; i < m_agButterflies.Length; i++)
        {
            // if there is a butterfly with the intial butterfly bool as true
            if (m_agButterflies[i].gameObject.GetComponent<Butterfly>().m_bInitalButterfly)
            {
                // start is true
                bStart = true;
            }
        }
        
        // if start is true
        if (bStart)
        {
            // loop through each butterfly.
            for (int i = 0; i < m_agButterflies.Length; i++)
            {
                // set each butterfly in the array to true
                m_agButterflies[i].SetActive(true);
            }

            // Start butterfly objective bool true.
            m_bStartButterfly = true;
        }
    }
}