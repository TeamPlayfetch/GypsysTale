﻿//--------------------------------------------------------------------------------------
// Purpose: Handles the functionality of the main menu UI.
//
// Description: This script is used for the main functionality of the main menu buttons 
// and UI. This script is to be attached to the EventSystem after creating a canvas for 
// the scene. Once attached apply the EventSystem as the object for the onClick of the 
// desired UI button.
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;
using UnityEngine.UI;

//--------------------------------------------------------------------------------------
// MainMenuUI object. Inheriting from BaseCollectable. The main class for mainmenu 
// functionality.
//--------------------------------------------------------------------------------------
public class MainMenuUI : MonoBehaviour
{
    // PLAY BUTTON //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Play Button:")]

    // public string for the scene to chnage from the play button.
    [LabelOverride("Play Button Destination Scene")] [Tooltip("The Scene to be changed to when pushing this button.")]
    public string m_sPlayDestination;
    
    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // AUDIO //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Audio:")]

    // public audio clip for start audio.
    [LabelOverride("Start Game")] [Tooltip("The Audio Clip to be used for the Start Button selection.")]
    public AudioClip m_acSelectAudio;

    // public audio clip for toggle audio.
    [LabelOverride("Button Toggle")] [Tooltip("The Audio Clip to be used when toggling between buttons.")]
    public AudioClip m_acToggleAudio;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // UI //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("UI:")]

    // public gameobject for the fadeout object
    [LabelOverride("Fade Out Object")] [Tooltip("The object that contains an image component that will be faded out on button presses.")]
    public GameObject m_gFadeObject;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private AudioSource value
    private AudioSource m_asAudioSource;

    // private float value for a timer
    private float m_fTimer = 0.0f;

    // private image value for the fade out image
    private Image m_iFadeImage;

    // private bool value for fading out
    private bool m_bFade = false;
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    void Awake()
    {
        // get audio source component
        m_asAudioSource = GetComponent<AudioSource>();
        
        // get image component from fadeout object
        m_iFadeImage = m_gFadeObject.GetComponent<Image>();
    }
    
    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {
        // if the fade is true
        if (m_bFade)
        {
            // Start timer.
            m_fTimer += Time.deltaTime;

            // get the fade image color
            Color cColor = m_iFadeImage.color;

            // fade image alpha by deltatime
            cColor.a += Time.deltaTime;

            //fade image
            m_iFadeImage.color = cColor;

            // if timer is greater than 2
            if (m_fTimer > 1.0f)
            { 
                // Change to another scene
                SceneManager.LoadScene(m_sPlayDestination);
            }
        }
    }

    //--------------------------------------------------------------------------------------
    // SelectSound: Function for playing button toggle sounds in the mainmenu.
    //--------------------------------------------------------------------------------------
    public void SelectSound()
    {
        // Play the audio.
        m_asAudioSource.PlayOneShot(m_acToggleAudio);
    }
    
    //--------------------------------------------------------------------------------------
    // PlayButton: Function for the Play button on interaction.
    //--------------------------------------------------------------------------------------
    public void PlayButton()
    {
        // fade the main menu out
        m_bFade = true;

        // Play audio selected button audio
        m_asAudioSource.PlayOneShot(m_acSelectAudio);
    }

    //--------------------------------------------------------------------------------------
    // CreditsButton: Function for the Credits button on interaction.
    //--------------------------------------------------------------------------------------
    public void CreditsButton()
    {
        // TODO

        // Play audio selected button audio
        m_asAudioSource.PlayOneShot(m_acSelectAudio);
    }

    //--------------------------------------------------------------------------------------
    // ExitGame: Function for the Exit button on interaction.
    //--------------------------------------------------------------------------------------
    public void ExitGame()
    {
        // Play audio selected button audio
        m_asAudioSource.PlayOneShot(m_acSelectAudio);

        // Close application.
        Application.Quit();

        // Check that quit is actually being fired.
        Debug.Log("Game is exiting");
    }
}

// LOADING SCREEN POSSIBLY
// https://blog.teamtreehouse.com/make-loading-screen-unity