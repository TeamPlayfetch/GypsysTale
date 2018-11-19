//--------------------------------------------------------------------------------------
// Purpose: Manages the pausing of the game.
//
// Description: This script will manage the state of game pause throughout the game.
// Attach to an empty gameobject.
//
// Author: Thomas Wiltshire.
//--------------------------------------------------------------------------------------

// Using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;
using UnityEngine.UI;

//--------------------------------------------------------------------------------------
// PauseManager object. Inheriting from MonoBehaviour. Manager for the pausing state.
//--------------------------------------------------------------------------------------
public class PauseManager : MonoBehaviour
{
    // MAIN MENU BUTTON //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Main Menu Button:")]

    // public string for the scene to chnage from the mainmenu button.
    [LabelOverride("MainMenu Button Destination Scene")]
    [Tooltip("The Scene to be changed to when pushing this button.")]
    public string m_sMainMenuDestination;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // AUDIO //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Audio:")]

    // public audio clip for start audio.
    [LabelOverride("Start Game")]
    [Tooltip("The Audio Clip to be used for the Start Button selection.")]
    public AudioClip m_acSelectAudio;

    // public audio clip for toggle audio.
    [LabelOverride("Button Toggle")]
    [Tooltip("The Audio Clip to be used when toggling between buttons.")]
    public AudioClip m_acToggleAudio;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // PUBLIC HIDDEN //
    //--------------------------------------------------------------------------------------
    // public static bool for if the game is paused.
    [HideInInspector]
    public static bool ms_bPaused;

    // public gameobject for pause canvas.
    [HideInInspector]
    public GameObject m_gCanvas;
    //--------------------------------------------------------------------------------------

    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private AudioSource value
    private AudioSource m_asAudioSource;

    // private gameobject for the selected object in the menu
    private GameObject m_gSelectedButton;
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    void Awake()
    {
        // Get the Pause canvas gameobject.
        m_gCanvas = GameObject.FindGameObjectWithTag("PauseCanvas");

        // Check if there is a valid pause canvas.
        if (m_gCanvas != null)
            m_gCanvas.SetActive(false);

        // set the default for pause to false.
        ms_bPaused = false;
        
        // get the currently selected button
        m_gSelectedButton = EventSystem.current.currentSelectedGameObject;

        // get audio source component
        m_asAudioSource = GetComponent<AudioSource>();
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {
        // Check if the pause button was pressed.
        if (XCI.GetButtonUp(XboxButton.Start))
        {
            // toggle pause bool.
            ms_bPaused = !ms_bPaused;
        }

        // if paused.
        if (ms_bPaused)
        {
            // Check if there is a valid pause canvas
            if (m_gCanvas != null)
            {
                // Set the pause canvas to true.
                m_gCanvas.SetActive(true);
            }

            // pause the audio
            AudioListener.pause = true;

            // stop game clock.
            Time.timeScale = 0;
        }

        // if not paused.
        else if (!ms_bPaused)
        {
            // Check if there is a valid pause canvas.
            if (m_gCanvas != null)
            {
                // Set the pause canvas to false.
                m_gCanvas.SetActive(false);
            }

            // unpause the audio
            AudioListener.pause = false;

            // start game clock.
            Time.timeScale = 1;
        }
        
        // if there is no current button than select one
        if (EventSystem.current.currentSelectedGameObject == null)
            EventSystem.current.SetSelectedGameObject(m_gSelectedButton);

        // make sure that the selected button is the currently selected.
        m_gSelectedButton = EventSystem.current.currentSelectedGameObject;
    }

    //--------------------------------------------------------------------------------------
    // OnApplicationFocus: Returns true or false if the window has focus.
    //
    // Param:
    //      hasFocus: bool for if the window has lost focus.
    //--------------------------------------------------------------------------------------
    void OnApplicationFocus(bool hasFocus)
    {    
        // toggle pause bool.
        if (!hasFocus)
            ms_bPaused = true;
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
