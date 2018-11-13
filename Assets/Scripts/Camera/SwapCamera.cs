//--------------------------------------------------------------------------------------
// Purpose: Switch the main scene camera.
//
// Description: This script is used for switching between different cameras for various 
// objectives and areas. This script can be attached to Trigger boxes or interactable 
// objects. 
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//--------------------------------------------------------------------------------------
// SwapCamera object. Inheriting from MonoBehaviour. The main class for switching 
// cameras in the scene.
//--------------------------------------------------------------------------------------
public class SwapCamera : MonoBehaviour
{

    // CAMERAS //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Camera:")]

    // public gameobject for the new camera
    [LabelOverride("New Camera")] [Tooltip("The desired camera to swap to.")]
    public GameObject m_gNewCamera;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // SWAP SETTINGS //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Swap Settings:")]

    // public bool for if the camera will swap back.
    [LabelOverride("Swap Camera back?")] [Tooltip("Will the camera return back to the main camera after the change?")]
    public bool m_bReturnCamera = false;

    // public float for the time it takes to swap back.
    [LabelOverride("Swapping Time")] [Tooltip("The time it will take after a camera change to swap back.")]
    public float m_fSwapTime = 3.0f;
 
    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // FADE //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Fade Out Settings:")]

    // public bool for if the camera will fade out or not
    [LabelOverride("Fade out?")] [Tooltip("Is there a fadeout for this camera instead of chnage back to main?")]
    public bool m_bFadeOut = false;

    // public float for the fadeout time.
    [LabelOverride("Fade out time")] [Tooltip("The it takes after camera change for the fade out to start.")]
    public float m_fFadeOutTime = 0.0f;

    // public gameobject for the fadeout image.
    [LabelOverride("Fade Image")] [Tooltip("The gameobject with image component used for the fading of the camera.")]
    public GameObject m_gFadeObject;




    public float m_fFadeSpeed = 1.0f;




    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // OTHER //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Other Settings:")]

    // public bool for if the script is on a trigger box
    [LabelOverride("Change Camera onTrigger?")] [Tooltip("Tick if you want the camera to swap on a trigger instead of interaction with another object.")]
    public bool m_bTriggerSwap = true;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // PUBLIC HIDDEN //
    //--------------------------------------------------------------------------------------
    // public bool for if an interaction has happened
    [HideInInspector]
    public bool m_bInteracted = false;
    //--------------------------------------------------------------------------------------

    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private float value for the timer.
    private float m_fTimer = 0.0f;

    // private bool value for if the camera has swapped.
    private bool m_bSwapped = false;

    // private image value for the fade out image
    private Image m_iFadeImage;

    // private collider for the triggerbox
    private Collider m_cTriggerBox;

    // private player object
    private Player m_sPlayerObject;
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    void Awake()
    {
        // get image component from fadeout object
        if (m_gFadeObject != null)
            m_iFadeImage = m_gFadeObject.GetComponent<Image>();

        // get triggerbox
        m_cTriggerBox = GetComponent<Collider>();
        
        // Set the player script object to the player script.
        m_sPlayerObject = GameObject.Find("Player").GetComponent<Player>();
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update ()
    {
        // Start timer.
        m_fTimer += Time.deltaTime;

        // check if the player has interacted
        Interacted();

        // if the camera is to return
        if (m_bReturnCamera && m_bSwapped)
        {
            // if timer is over swaptime
            if (m_fTimer > m_fSwapTime)
            {
                // Return to the main camera
                ReturnToMain();
            }
        }

        // if the timer is greater than the fadeout time.
        if (m_fTimer > m_fFadeOutTime)
        {
            // if fade out and swapped
            if (m_bFadeOut && m_bSwapped)
            {
                // get the fade image color
                Color cColor = m_iFadeImage.color;

                // fade image alpha by deltatime
                cColor.a += m_fFadeSpeed * Time.deltaTime;

                //fade image
                m_iFadeImage.color = cColor;
            }
        }
	}

    //--------------------------------------------------------------------------------------
    // ReturnToMain: Returns the current camera to the main player camera.
    //--------------------------------------------------------------------------------------
    void ReturnToMain()
    {
        // main camera is true and new is false
        m_gNewCamera.SetActive(false);

        // swapped back to false
        m_bSwapped = false;
        
        // enable player movement again
        m_sPlayerObject.m_bStopMovement = false;
        
        // disable the script after use
        this.enabled = false;
    }

    //--------------------------------------------------------------------------------------
    // Interacted: Changes the camera on player interaction with another object.
    //--------------------------------------------------------------------------------------
    void Interacted()
    {
        // if interacted
        if (m_bInteracted)
        {
            // Swap camera on trigger
            m_gNewCamera.SetActive(true);

            // camera has swapped
            m_bSwapped = true;

            // reset the timer
            m_fTimer = 0.0f;

            // turn off interacted
            m_bInteracted = false;
            
            // stop the player movement during camera changes
            m_sPlayerObject.m_bStopMovement = true;
        }
    }

    //--------------------------------------------------------------------------------------
    // OnTriggerEnter: OnTriggerEnter is called when the Collider cObject enters the trigger.
    //
    // Param:
    //      cObject: The other Collider invloved in the collision.
    //--------------------------------------------------------------------------------------
    void OnTriggerEnter(Collider cObject)
    {
        if (m_bTriggerSwap)
        {
            // if the player is tag
            if (cObject.tag == "Player")
            {
                // Swap camera on trigger
                m_gNewCamera.SetActive(true);

                // camera has swapped
                m_bSwapped = true;

                // turn off trigger box
                m_cTriggerBox.isTrigger = false;

                // reset the timer
                m_fTimer = 0.0f;
                
                // stop the player movement during camera changes
                m_sPlayerObject.m_bStopMovement = true;

                // camera trigger is false
                m_bTriggerSwap = false;
            }
        }
    }
}