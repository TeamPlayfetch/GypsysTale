//--------------------------------------------------------------------------------------
// Purpose: Interaction logic for the PhotoBomb object.
//
// Description: This script will take care of the logic when the PhotoBomb object is 
// interacted with by the player. This script is to be attached to an empty game object.
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// PhotoBomb object. Inheriting from MonoBehaviour. The PhotoBomb interactable object.
//--------------------------------------------------------------------------------------
public class PhotoBomb : MonoBehaviour
{
    // SETTINGS //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Photo Settings:")]

    // public float for the time of the photo.
    [LabelOverride("Time of Photo")] [Tooltip("The time in seconds for when the photo will be taken.")]
    public float m_fPhotoTime = 8.0f;

    // public float for the reset delay of the timer.
    [LabelOverride("Reset Delay")] [Tooltip("Delay before the timer resets in seconds.")]
    public float m_fResetDelay = 10.0f;

    // public float for the window of which the play can be in the photo.
    [LabelOverride("Bombing Window")] [Tooltip("Bombing window in seconds for the player to jump in frame.")]
    public float m_fBombingWindow = 1.0f;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("GUI Settings:")]

    // public gameobject for the image to display
    [LabelOverride("Canvas Image")] [Tooltip("The image to be displayed on the canvas for completing the objective.")]
    public GameObject m_gUIImage;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // DEBUG //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Debug:")]

    // public bool for turning the debug info off and on.
    [LabelOverride("Display Debug Info?")] [Tooltip("Turns off and on debug information in the unity console.")]
    public bool m_bDebugMode = true;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // PUBLIC HIDDEN //
    //--------------------------------------------------------------------------------------
    // public hidden bool for if the objective is complete.
    [HideInInspector]
    public bool m_bObjectiveComplete = false;

    // public hidden float for the photo timer.
    [HideInInspector]
    public float m_fTimer = 0.0f;

    // public bool for if the mini game is failed or not.
    [HideInInspector]
    public bool m_bFailed = false;

    // public bool for flash animation 1.
    [HideInInspector]
    public bool m_bRedFlashAni = false;

    // public bool for flash animation 2.
    [HideInInspector]
    public bool m_bWhiteFlashAni = false;

    // public bool for if the reseting animation.
    [HideInInspector]
    public bool m_bResetAni = false;
    //--------------------------------------------------------------------------------------

    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private bool for the if the player is in the photo or not.
    private bool m_bPlayerInPhoto;

    // private objectivemanager object for getting the objective manager script.
    private ObjectiveManager m_sObjectiveManager;

    // private animator for the camera animator
    private Animator m_aniAnimator;

    // private bool for if the objectve is complete.
    private bool m_bMarkComplete = false;

    // private bool for if the photo is complete
    private bool m_bPhotoComplete = false;
    //--------------------------------------------------------------------------------------






    public AudioClip m_acFlashAudio;

    // private audio source
    private AudioSource m_asAudioSource;






    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    void Awake()
    {
        // Set the ObjectiveManager script object to the ObjectiveManager script.
        m_sObjectiveManager = GameObject.Find("Player").GetComponent<ObjectiveManager>();

        // Subscribe the function ObjectiveProgress with the ObjectiveProgressCallback delegate event
        m_sObjectiveManager.ObjectiveProgressCallback += ObjectiveProgress;

        // Get the animator component of the camera
        m_aniAnimator = GetComponentInChildren<Animator>();

        // get the audiosource component of the photobomb object
        m_asAudioSource = GetComponent<AudioSource>();
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {
        // set animation bools
        m_aniAnimator.SetBool("Red Flash", m_bRedFlashAni);
        m_aniAnimator.SetBool("White Flash", m_bWhiteFlashAni);

        // Start timer.
        m_fTimer += Time.deltaTime;

        // if the timer is over the photo time
        if (m_fTimer > m_fPhotoTime)
        {
            // is the objective complete?
            if (!m_bPhotoComplete)
            {
                // delay timer reset
                if (m_fTimer > m_fResetDelay)
                {
                    // reset timer
                    m_fTimer = 0.0f;
                }
            }
        }

        // if timer is over the bombing window and under the photo time
        if (m_fTimer > (m_fPhotoTime - m_fBombingWindow) && m_fTimer < m_fPhotoTime)
        {
            // if the player is in photo frame
            if (m_bPlayerInPhoto)
            {
                // objective complete
                m_bPhotoComplete = true;
            }
        }

        // if the player is in frame and timer is under bombing window.
        else if (m_bPlayerInPhoto && m_fTimer < (m_fPhotoTime - m_fBombingWindow) && !m_bPhotoComplete)
        {
            // reset timer.
            m_fTimer = 0.0f;
        }

        // if the timer is 0 or timer is over the photo time and the player is in frame and objective not complete.
        if (m_fTimer < 0.2f || m_fTimer > m_fPhotoTime && m_bPlayerInPhoto && !m_bPhotoComplete)
        {
            // failed is true.
            m_bFailed = true;
        }

        // else if the timer is not 0 or above the phototime and player is not in frame then failed is false.
        else
            m_bFailed = false;

        // if the objective is complete
        if (m_bPhotoComplete)
        {
            // Set image on canvas to active
            if (m_fTimer > 8 && m_fTimer < 12)
                m_gUIImage.SetActive(true);

            // set image back to false
            else
                m_gUIImage.SetActive(false);

            // objective complete
            if (m_fTimer > 12)
                m_bObjectiveComplete = true;
        }

        // if the timer is 0 reset the animation function
        if (m_fTimer < 0.2f)
            m_bResetAni = true;

        // play flash animations
        AnimateFlashes();
    }

    //--------------------------------------------------------------------------------------
    // AnimateFlashes: Animates the camera flashes for each stage of the objective.
    //--------------------------------------------------------------------------------------
    void AnimateFlashes()
    {
       // if the flash reset is true
       if (m_bResetAni)
        {
            // set the flash animation 3 to false
            m_bWhiteFlashAni = false;

            // red flash
            if (m_fTimer > (m_fPhotoTime - (m_fBombingWindow)))
            {
                // debug camera Flash
                if (m_bDebugMode)
                    Debug.Log("Red Flash");

                // set animation
                m_bRedFlashAni = true;
            }

            // Camera flash
            if (m_fTimer > m_fPhotoTime)
            {
                // debug camera Flash
                if (m_bDebugMode)
                    Debug.Log("White Flash");

                // play the flash audio
                m_asAudioSource.PlayOneShot(m_acFlashAudio);

                // set animation bools to false
                m_bRedFlashAni = false;
                m_bWhiteFlashAni = true;
                m_bResetAni = false;
            }
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
        }
    }

    //--------------------------------------------------------------------------------------
    // OnTriggerEnter: OnTriggerEnter is called when the Collider cObject enters the trigger.
    //
    // Param:
    //      cObject: The other Collider invloved in the collision.
    //--------------------------------------------------------------------------------------
    private void OnTriggerEnter(Collider cObject)
    {
        // if collides is player
        if (cObject.tag == "Player")
        {
            // Player is in the photo frame.
            m_bPlayerInPhoto = true;
        }
    }

    //--------------------------------------------------------------------------------------
    // OnTriggerExit: OnTriggerExit is called when the Collider cObject exits the trigger.
    //
    // Param:
    //      cObject: The other Collider invloved in the collision.
    //--------------------------------------------------------------------------------------
    private void OnTriggerExit(Collider cObject)
    {
        // if collide is player
        if (cObject.tag == "Player")
        {
            // Player is out of photo frame.
            m_bPlayerInPhoto = false;
        }
    }
}