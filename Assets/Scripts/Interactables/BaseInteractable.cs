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
    [LabelOverride("Single Use")] [Tooltip("Is this interactable object for single use or can it be interacted with again later?")]
    public bool m_bSingleUse;
    //--------------------------------------------------------------------------------------

    // PROTECTED VALUES //
    //--------------------------------------------------------------------------------------
    // private player script for getting the player objects attached script.
    protected Player m_sPlayerObject;

    // protected bool for if the object has been interacted with or not.
    protected bool m_bInteracted;
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
            // Subscribe the function InteractedWith with the InteractionEvent delegate event
            m_sPlayerObject.InteractionCallback += InteractedWith;
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
            // Unsubscribe the function InteractedWith with the InteractionEvent delegate event
            m_sPlayerObject.InteractionCallback -= InteractedWith;
        }
    }

    //--------------------------------------------------------------------------------------
    // InteractedWith: Virtual function for what Interactable objects do once they have 
    // been interacted with.
    //--------------------------------------------------------------------------------------
    protected virtual void InteractedWith()
    {
        // Display debug message showing interaction.
        Debug.Log("Interaction Triggered");

        // if the interactable is not single use.
        if (!m_bSingleUse)
        {
            // the object is finished being interacted with
            m_bInteracted = false;
        }

        // if the interactable is single use.
        else if (m_bSingleUse)
        {
            // the object has been interacted with.
            m_bInteracted = true;

            // Make sure that the function is being unsubscribed from the delegate.
            m_sPlayerObject.InteractionCallback -= InteractedWith;
        }
    }
}
