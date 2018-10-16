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
using UnityEngine.UI;

//--------------------------------------------------------------------------------------
// StartCams object. Inheriting from MonoBehaviour. Switches between multiple cameras 
// at the start of the game.
//--------------------------------------------------------------------------------------
public class StartCams : MonoBehaviour
{
    // CAMERAS //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Cameras:")]

    // public  gameobject for the main camera of the game.
    [LabelOverride("Main Camera")] [Tooltip("The main camera of the player used in the game.")]
    public GameObject m_gMainCamera;
    
    // public array of gameobjects for the cameras to swap
    [LabelOverride("Cameras")] [Tooltip("An array of cameras to swap between every few seconds.")]
    public GameObject[] m_agCameras;
    
    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // SWAP SETTINGS //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Swap Settings:")]

    // public float for the time it takes to swap back.
    [LabelOverride("Swapping Time")] [Tooltip("The time it will take after a camera change to swap back.")]
    public float m_fSwapTime = 3.0f;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private float value for the timer.
    private float m_fTimer = 0.0f;

    // private bool value for if the camera has swapped.
    private bool m_bSwapped = false;

    // private collider for the triggerbox
    private Collider m_cTriggerBox;
    
    // private int for the current active camera.
    private int m_nCurrentCamera = 0;
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    void Awake()
    {
        // loop through each camera
        for (int i = 0; i < m_agCameras.Length; ++i)
        {
            // set each camera to false
            m_agCameras[i].SetActive(false);
        }

        // get triggerbox
        m_cTriggerBox = GetComponent<Collider>();
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {
        // Start timer.
        m_fTimer += Time.deltaTime;

        // if the camera is to return
        if (m_bSwapped)
        {
            // if timer is over swaptime
            if (m_fTimer > m_fSwapTime)
            {
                // Swap to the next camera
                NextCamera();
            }
        }
    }

    //--------------------------------------------------------------------------------------
    // NextCamera: Swap the view between all the differnt cameras.
    //--------------------------------------------------------------------------------------
    void NextCamera()
    {
        // loop through each camera in the array
        for (int i = 0; i < m_agCameras.Length; i++)
        {
            // if a camera is active
            if (m_agCameras[i].activeSelf)
            {
                // Increase the current camera by 1
                m_nCurrentCamera = i + 1;

                // set camera to false
                m_agCameras[i].SetActive(false);
            }
        }

        // if the current camera is greater than the length -1
        if (m_nCurrentCamera > (m_agCameras.Length - 1))
        {
            //
            //m_gMainCamera.SetActive(true);

            // finished swapping cameras
            m_bSwapped = false;

            // destroy gameobject.
            Destroy(this.gameObject);
        }

        // if the current camera is less than the length of cameras set the current to true
        if (m_nCurrentCamera < m_agCameras.Length)
            m_agCameras[m_nCurrentCamera].SetActive(true);

        // reset the timer
        m_fTimer = 0.0f;
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
            // set main camera to false
            //m_gMainCamera.SetActive(false);

            // Set the camera to the first in the array
            m_agCameras[m_nCurrentCamera].SetActive(true);

            // camera has swapped
            m_bSwapped = true;

            // turn off trigger box
            m_cTriggerBox.isTrigger = false;

            // reset the timer
            m_fTimer = 0.0f;
        }
    }
}