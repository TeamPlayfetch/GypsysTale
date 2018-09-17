//--------------------------------------------------------------------------------------
// Purpose: Interaction logic for the frisbee object.
//
// Description: This script will take care of the logic when a frisbee is interacted with
// by the player. This script is to be attached to the frisbee object.
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// Frisbee object. Inheriting from BaseInteractable. The frisbee interactable object.
//--------------------------------------------------------------------------------------
public class Frisbee : BaseInteractable
{
    // LERP SETTINGS //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Lerp Settings:")]

    // public transform for where to start the movement lerp.
    [LabelOverride("Start Position")] [Tooltip("The starting position of the lerp.")]
    public Transform m_tStartPosition;

    // public transform for where to end the movement lerp.
    [LabelOverride("End Position")] [Tooltip("The ending position of the lerp.")]
    public Transform m_tEndPosition;

    // public float for the speed of the lerp.
    [LabelOverride("Lerp Duration")] [Tooltip("The duration of the lerp in seconds.")]
    public float m_fSpeed = 3.0f;

    // public float for the amount of time to pause the lerp.
    [LabelOverride("Throw Delay")] [Tooltip("The time in seconds between the next lerp.")]
    public float m_fThrowDelay = 3.0f;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // OTHER SETTINGS //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Other Settings:")]

    // public mesh renderer.
    [LabelOverride("Renderer")] [Tooltip("The renderer of the frisbee object.")]
    public Renderer m_rRenderer;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private bool for if the lerp is complete
    private bool m_bLerpComplete = false;

    // private float for current lerp postion.
    private float m_fCurrentLerpTime = 0.0f;

    // private float for delaying the lerp.
    private float m_fDelayTimer;

    // private vector3 for the start pos of the lerp.
    private Vector3 m_v3StartPos;

    // private vector3 for the end pos of the lerp.
    private Vector3 m_v3EndPos;

    // private vector3 to temp hold a lerp pos value while swaping.
    private Vector3 m_v3TempPos;
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    new void Awake()
    {
        // Run the base awake
        base.Awake();

        // Make sure the renderer is enabled
        m_rRenderer.enabled = true;

        // Set the start postion.
        m_v3StartPos = m_tStartPosition.position;

        // Set the end position
        m_v3EndPos = m_tEndPosition.position;

        // set the temp position
        m_v3TempPos = new Vector3(0.0f, 0.0f, 0.0f);
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {
        // Run the lerp function and assign value to lerp complete bool.
        m_bLerpComplete = Lerp(m_v3StartPos, m_v3EndPos);

        // if the lerp is complete.
        if (m_bLerpComplete)
        {
            // Start delay timer.
            m_fDelayTimer += Time.deltaTime;

            // if the delay timer is greater then the throw delay.
            if (m_fDelayTimer > m_fThrowDelay)
            {
                // swap the end and start pos values.
                m_v3TempPos = m_v3EndPos;
                m_v3EndPos = m_v3StartPos;
                m_v3StartPos = m_v3TempPos;

                // reset the time for the lerp.
                m_fCurrentLerpTime = 0.0f;

                // reset delay timer.
                m_fDelayTimer = 0.0f;
            }
        }
        
        // Set the postion to the postion of the interactable object with a slight offset.
        if (m_psBtnVisual != null)
            m_psBtnVisual.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);

        // Destroy Gameobjects if audio is done playing or has been interacted with
        if (m_bInteractAudio && !m_asAudioSource.isPlaying && m_bInteracted)
            Destroy(this.gameObject);
        else if (m_bInteracted && !m_bInteractAudio)
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

        // disable the mesh
        m_rRenderer.enabled = false;
    }

    //--------------------------------------------------------------------------------------
    // Lerp: Function to lerp the attached gameobject from one pass in transform to another.
    // 
    // Return:
    //      bool: Returns true once the lerp is complete.
    //--------------------------------------------------------------------------------------
    bool Lerp(Vector3 v3StartPos, Vector3 v3EndPos)
    {
        // update lerp timer by delta time.
        m_fCurrentLerpTime += Time.deltaTime;

        // Check if the current time is greater than the lerp time.
        if (m_fCurrentLerpTime > m_fSpeed)
        {
            // current time equels lerp time.
            m_fCurrentLerpTime = m_fSpeed;
        }

        // New float for the progress through the lerp.
        float fProgress = m_fCurrentLerpTime / m_fSpeed;

        // if current time is equal to speed.
        if (m_fCurrentLerpTime == m_fSpeed)
        {
            // Return true for the lerp is finished.
            return true;
        }

        // Lerp the text object and background
        transform.position = Vector3.Lerp(v3StartPos, v3EndPos, fProgress);

        // return false for not complete
        return false;
    }
}