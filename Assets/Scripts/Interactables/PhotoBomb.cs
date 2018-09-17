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
// PhotoBomb object. Inheriting from BaseInteractable. The PhotoBomb interactable object.
//--------------------------------------------------------------------------------------
public class PhotoBomb : BaseInteractable
{
    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    new void Awake()
    {
        // Run the base awake
        base.Awake();
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {
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
    }
}