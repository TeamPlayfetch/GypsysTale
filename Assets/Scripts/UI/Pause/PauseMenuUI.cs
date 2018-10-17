//--------------------------------------------------------------------------------------
// Purpose: Handles the functionality of the main menu UI.
//
// Description: This script is used for the main functionality of the pause menu buttons 
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

//--------------------------------------------------------------------------------------
// PauseMenuUI object. Inheriting from BaseCollectable. The main class for pause menu 
// functionality.
//--------------------------------------------------------------------------------------
public class PauseMenuUI : MonoBehaviour
{
    // MIN MENU BUTTON //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Main Menu Button:")]

    // public string for the scene to chnage from the mainmenu button.
    [LabelOverride("MainMenu Button Destination Scene")][Tooltip("The Scene to be changed to when pushing this button.")]
    public string m_sMainMenuDestination;
    
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

    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private AudioSource value
    private AudioSource m_asAudioSource;
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    void Awake()
    {
        // get audio source component
        m_asAudioSource = GetComponent<AudioSource>();
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
    // ResumeButton: Function for the Resume button on interaction.
    //--------------------------------------------------------------------------------------
    public void ResumeButton()
    {
        // Play audio selected button audio
        m_asAudioSource.PlayOneShot(m_acSelectAudio);

        // Unpause the game
        PauseManager.ms_bPaused = false;
    }

    //--------------------------------------------------------------------------------------
    // MainMenuButton: Function for the Mainmenu button on interaction.
    //--------------------------------------------------------------------------------------
    public void MainMenuButton()
    {
        // Play audio selected button audio
        m_asAudioSource.PlayOneShot(m_acSelectAudio);

        // Unpause the game on mainmenu return
        PauseManager.ms_bPaused = false;

        // Change to another scene
        SceneManager.LoadScene(m_sMainMenuDestination);
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
