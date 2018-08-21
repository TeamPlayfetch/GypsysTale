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
    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private player script for getting the player objects attached script.
    private Player m_sPlayerObject;
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    void Awake()
    {
        // Set the player script object to the player script.
        m_sPlayerObject = GameObject.Find("Player").GetComponent<Player>();
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {
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
            // Subscribe the function InteractedWith with the InteractionEvent delegate event
            m_sPlayerObject.InteractionEvent += InteractedWith;
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
            // Unsubscribe the function InteractedWith with the InteractionEvent delegate event
            m_sPlayerObject.InteractionEvent -= InteractedWith;
        }
    }

    //--------------------------------------------------------------------------------------
    // InteractedWith: Virtual function for what Interactable objects do once they have 
    // been interacted with.
    //--------------------------------------------------------------------------------------
    public virtual void InteractedWith() { }
}
