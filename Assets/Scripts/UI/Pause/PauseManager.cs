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
using XboxCtrlrInput;

//--------------------------------------------------------------------------------------
// PauseManager object. Inheriting from MonoBehaviour. Manager for the pausing state.
//--------------------------------------------------------------------------------------
public class PauseManager : MonoBehaviour
{
    // PUBLIC HIDDEN //
    //--------------------------------------------------------------------------------------
    // public static bool for if the game is paused.
    [HideInInspector]
    public static bool ms_bPaused;

    // public gameobject for pause canvas.
    [HideInInspector]
    public GameObject m_gCanvas;
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
    }

    //--------------------------------------------------------------------------------------
    // OnApplicationFocus: Returns true or false if the window has focus.
    //--------------------------------------------------------------------------------------
    void OnApplicationFocus(bool hasFocus)
    {    
        // toggle pause bool.
        if (!hasFocus)
            ms_bPaused = true;
    }
}
