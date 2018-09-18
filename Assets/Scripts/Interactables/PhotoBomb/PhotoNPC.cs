//--------------------------------------------------------------------------------------
// Purpose: Turn the photobomb NPC towards the camera or player.
//
// Description: This script will take care of the logic with the PhotoBomb npcs. This 
// script is to be attached to a photobomb npc object.
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
public class PhotoNPC : MonoBehaviour
{
    // SETTINGS //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Settings:")]

    // public transform for camera position.
    [LabelOverride("PhotoBomb Camera")] [Tooltip("The camera object being used for the photobomb minigame.")]
    public Transform m_tCamera;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private player script
    private Player m_sPlayerObject;

    // private photobomb script
    private PhotoBomb m_sPhotoBombObject;
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    void Awake ()
    {
        // Set the photobomb script object to the photobomb script.
        m_sPhotoBombObject = GameObject.Find("PhotoBomb").GetComponent<PhotoBomb>();

        // Set the player script object to the player script.
        m_sPlayerObject = GameObject.Find("Player").GetComponent<Player>();
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update ()
    {
        // if the timer is 0 look at the player.
        if (m_sPhotoBombObject.m_bFailed)
            transform.LookAt(m_sPlayerObject.transform);

        // else if the timer is ticking look at the camera
        else
            transform.LookAt(m_tCamera);
    }
}