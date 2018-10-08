//--------------------------------------------------------------------------------------
// Purpose: Handles the functionality of the main menu UI.
//
// Description: This script is used for the main functionality of the main menu buttons 
// and UI. This script is to be attached to the EventSystem after creating a canvas for 
// the scene. Once attached apply the EventSystem as the object for the onClick of the 
// desired UI button.
//
// Author: Thomas Wiltshire
//
// Edited: Zane Talbot
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

//--------------------------------------------------------------------------------------
// MainMenuUI object. Inheriting from BaseCollectable. The main class for mainmenu 
// functionality.
//--------------------------------------------------------------------------------------
public class MainMenuUI : MonoBehaviour
{
    // public string for the scene to chnage from the play button.
    [LabelOverride("Play Button Destination Scene")] [Tooltip("The Scene to be changed to when pushing this button.")]
    public string m_sPlayDestination;

    // private Audio Source to output different audio on event
    private AudioSource m_asAudioSource;

    [LabelOverride("Start Game Sound")] [Tooltip("The Audio Clip to be used for the Start Button.")]
    // public audio clip for starting the game
    public AudioClip m_acStartGame;

    [LabelOverride("Toggle Button Sound")] [Tooltip("The Audio Clip to be used when toggling between buttons.")]
    // public audio clip for button hovering
    public AudioClip m_acToggleButtons;

    private void Awake()
    {
        m_asAudioSource = GetComponent<AudioSource>();
    }

    //--------------------------------------------------------------------------------------
    // Toggle Sound: Function for button sounds in the Main Menu
    //--------------------------------------------------------------------------------------
    public void ToggleSound()
    {
        // Play the toggle button audio on button hover
        m_asAudioSource.PlayOneShot(m_acToggleButtons);
    }

    //--------------------------------------------------------------------------------------
    // PlayButton: Function for the Play button on interaction.
    //--------------------------------------------------------------------------------------
    public void PlayButton()
    {
        // Change to another scene
        SceneManager.LoadScene(m_sPlayDestination);

        // Play audio
        m_asAudioSource.PlayOneShot(m_acStartGame);
    }

    //--------------------------------------------------------------------------------------
    // CreditsButton: Function for the Credits button on interaction.
    //--------------------------------------------------------------------------------------
    public void CreditsButton()
    {
        // TODO
    }

    //--------------------------------------------------------------------------------------
    // ExitGame: Function for the Exit button on interaction.
    //--------------------------------------------------------------------------------------
    public void ExitGame()
    {
        // Close application.
        Application.Quit();

        // Check that quit is actually being fired.
        Debug.Log("Game is exiting");
    }
}
