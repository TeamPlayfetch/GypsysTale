//--------------------------------------------------------------------------------------
// Purpose: The base script for all interactable objects.
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// BaseInteractable object. Inheriting from MonoBehaviour. Base object for interactable
// objects.
//--------------------------------------------------------------------------------------
public class BaseInteractable : MonoBehaviour
{
    // INTERACTABLE SETTINGS //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Interactable Settings:")]

    // public bool for if the interactble is single use or not.
    [LabelOverride("Single Use?")] [Tooltip("Is this interactable object for single use or can it be interacted with again later?")]
    public bool m_bSingleUse;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // VISUAL INDICATOR //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Visual Indicator:")]

    // public particle system for button visual.
    [LabelOverride("Button Visual")] [Tooltip("Particle System for the Interactable Button Indicator.")]
    public ParticleSystem m_psBtnVisual;

    // public bool for if using a custom postion.
    [LabelOverride("Has custom position?")] [Tooltip("Tick this bool if the position used is custom then enter the position below.")]
    public bool m_bCustomPos = false;

    // public vector3 pos for button visual.
    [LabelOverride("Button Visual Positon")] [Tooltip("Postion of the Particle System for the Interactable Button Indicator.")]
    public Vector3 m_v3BtnVisualPos;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // AUDIO //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Audio:")]

    // public bool to give the option for audio or not.
    [LabelOverride("Has Interact Audio?")] [Tooltip("Is there interaction audio for this interactable object?")]
    public bool m_bInteractAudio = false;

    // public audioclip for interaction audio.
    [LabelOverride("Interact Audio")] [Tooltip("The audio clip for what will play when the interactable is interacted with.")]
    public AudioClip m_acInteractAudio;
    
    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // PROTECTED VALUES //
    //--------------------------------------------------------------------------------------
    // protected player script for getting the player objects attached script.
    protected Player m_sPlayerObject;

    // protected bool for if the object has been interacted with or not.
    protected bool m_bInteracted;

    // protected audio source
    protected AudioSource m_asAudioSource;
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    protected void Awake()
    {
        // Set the player script object to the player script.
        m_sPlayerObject = GameObject.Find("Player").GetComponent<Player>();

        // Set the interacted bool to false for starting.
        m_bInteracted = false;
        
        // if not using custom inspector postion
        if (!m_bCustomPos)
        {
            // set the postion to the postion of the interactable object with a slight offset
            m_v3BtnVisualPos = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
        }

        // Instantiate the particle system for the button visual.
        m_psBtnVisual = Instantiate(m_psBtnVisual, m_v3BtnVisualPos, Quaternion.identity);

        // disable the particle system
        m_psBtnVisual.Stop();

        //if there is an audio clip on the object.
        if (m_bInteractAudio)
        {
            // get the audiosource component of the interactable object
            m_asAudioSource = GetComponent<AudioSource>();
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
        if (cObject.tag == "Player" && !m_bInteracted)
        {
            // Display debug message showing interaction.
            if (m_sPlayerObject.m_bDebugMode)
                Debug.Log("Subscribed for Interaction");

            // Subscribe the function InteractedWith with the InteractionEvent delegate event
            m_sPlayerObject.InteractionCallback += InteractedWith;

            // Enable the particle system for button visual
            m_psBtnVisual.Play();
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
        if (cObject.tag == "Player" && m_sPlayerObject.InteractionCallback != null)
        {
            // Display debug message showing interaction.
            if (m_sPlayerObject.m_bDebugMode)
                Debug.Log("Unsubscribed for Interaction");

            // Unsubscribe the function InteractedWith with the InteractionEvent delegate event
            m_sPlayerObject.InteractionCallback -= InteractedWith;

            // disable the particle system for button visual
            m_psBtnVisual.Stop();
        }
    }

    //--------------------------------------------------------------------------------------
    // InteractedWith: Virtual function for what Interactable objects do once they have 
    // been interacted with.
    //--------------------------------------------------------------------------------------
    protected virtual void InteractedWith()
    {
        // Display debug message showing interaction.
        if (m_sPlayerObject.m_bDebugMode)
            Debug.Log("Interaction Triggered");

        // if the interactable is not single use.
        if (!m_bSingleUse)
        {
            // the object is finished being interacted with
            m_bInteracted = false;

            // Play Interaction Audio.
            if (m_bInteractAudio)
                m_asAudioSource.PlayOneShot(m_acInteractAudio);
        }

        // if the interactable is single use.
        else if (m_bSingleUse)
        {
            // the object has been interacted with.
            m_bInteracted = true;

            // Make sure that the function is being unsubscribed from the delegate.
            m_sPlayerObject.InteractionCallback -= InteractedWith;

            // disable the particle system for button visual
            m_psBtnVisual.Stop();

            // destroy particle effect.
            Destroy(m_psBtnVisual.gameObject);

            // if interaction audio is being used.
            if (m_bInteractAudio)
            {
                // Stop any previously playing audio
                if (m_asAudioSource.isPlaying)
                    m_asAudioSource.Stop();

                // Play Interaction Audio.
                m_asAudioSource.PlayOneShot(m_acInteractAudio);
            }
        }
    }
}
