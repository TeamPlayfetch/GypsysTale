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

    // PUBLIC HIDDEN //
    //--------------------------------------------------------------------------------------
    // public hidden bool for if the objective is complete.
    //[HideInInspector]
    public bool m_bObjectiveComplete = false;

    // public hidden float for the photo timer.
    //[HideInInspector]
    public float m_fTimer = 0.0f;

    // public bool for if the mini game is failed or not.
    //[HideInInspector]
    public bool m_bFailed = false;
    //--------------------------------------------------------------------------------------

    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private bool for if the photo has been taken or not.
    private bool m_bPhotoTaken = false;

    // private bool for the if the player is in the photo or not.
    private bool m_bPlayerInPhoto;
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
        // Start timer.
        m_fTimer += Time.deltaTime;

        // if the timer is over the photo time
        if (m_fTimer > m_fPhotoTime)
        {
            // photo is taken
            m_bPhotoTaken = true;

            // is the objective complete?
            if (!m_bObjectiveComplete)
            {
                // delay timer reset
                if (m_fTimer > m_fResetDelay)
                {
                    // reset timer
                    m_fTimer = 0.0f;

                    // mark photo to be taken again
                    m_bPhotoTaken = false;
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
                m_bObjectiveComplete = true;
            }
        }

        // if the player is in frame and timer is under bombing window.
        else if (m_bPlayerInPhoto && m_fTimer < (m_fPhotoTime - m_fBombingWindow))
        {
            // reset timer.
            m_fTimer = 0.0f;
        }

        // if the timer is 0 or timer is over the photo time and the player is in frame and objective not complete.
        if (m_fTimer == 0.0f || m_fTimer > m_fPhotoTime && m_bPlayerInPhoto && !m_bObjectiveComplete)
        {
            // failed is true.
            m_bFailed = true;
        }

        // else if the timer is not 0 or above the phototime and player is not in frame then failed is false.
        else
            m_bFailed = false;
        
        // if the objective is complete
        if (m_bObjectiveComplete)
        {
            // Set image on canvas to active
            if (m_fTimer > 9 && m_fTimer < 13)
                m_gUIImage.SetActive(true);

            // Set image on canvas to false
            else
                m_gUIImage.SetActive(false);
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