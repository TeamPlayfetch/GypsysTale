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
    // public string for the scene to chnage from the mainmenu button.
    [LabelOverride("MainMenu Button Destination Scene")][Tooltip("The Scene to be changed to when pushing this button.")]
    public string m_sMainMenuDestination;

    //--------------------------------------------------------------------------------------
    // ResumeButton: Function for the Resume button on interaction.
    //--------------------------------------------------------------------------------------
    public void ResumeButton()
    {
        // Unpause the game
        PauseManager.ms_bPaused = false;
    }

    //--------------------------------------------------------------------------------------
    // MainMenuButton: Function for the Mainmenu button on interaction.
    //--------------------------------------------------------------------------------------
    public void MainMenuButton()
    {
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
        // Close application.
        Application.Quit();

        // Check that quit is actually being fired.
        Debug.Log("Game is exiting");
    }
}
