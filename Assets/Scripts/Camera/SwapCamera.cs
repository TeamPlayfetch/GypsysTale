//--------------------------------------------------------------------------------------
// Purpose: Switch the main scene camera.
//
// Description: 
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// SwapCamera object. Inheriting from MonoBehaviour. The main class for switching 
// cameras in the scene.
//--------------------------------------------------------------------------------------
public class SwapCamera : MonoBehaviour
{




    public GameObject m_gMainCamera;

    public GameObject m_gNewCamera;
    
    public float m_fSwapTime = 3.0f;

    public bool m_bReturnCamera = false;



    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private float value for the timer.
    private float m_fTimer = 0.0f;

    // private bool value for if the camera has swapped.
    private bool m_bSwapped = false;
    
    //
    //private int
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    void Awake()
    {
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update ()
    {
        // Start timer.
        m_fTimer += Time.deltaTime;

        // if the camera is to return
        if (m_bReturnCamera && m_bSwapped)
        {
            // if timer is over swaptime
            if (m_fTimer > m_fSwapTime)
            {
                // Return to the main camera
                ReturnToMain();
            }
        }
	}

    //--------------------------------------------------------------------------------------
    // ReturnToMain: Returns the current camera to the main player camera.
    //--------------------------------------------------------------------------------------
    void ReturnToMain()
    {
        // main camera is true and new is false
        m_gMainCamera.SetActive(true);
        m_gNewCamera.SetActive(false);
    }

    //--------------------------------------------------------------------------------------
    // OnTriggerEnter: OnTriggerEnter is called when the Collider cObject enters the trigger.
    //
    // Param:
    //      cObject: The other Collider invloved in the collision.
    //--------------------------------------------------------------------------------------
    void OnTriggerEnter(Collider cObject)
    {
        // if the player is tag
        if (cObject.tag == "Player")
        {
            // Swap camera on trigger
            m_gMainCamera.SetActive(false);
            m_gNewCamera.SetActive(true);

            // reset the timer
            m_fTimer = 0.0f;
        }
    }
}
