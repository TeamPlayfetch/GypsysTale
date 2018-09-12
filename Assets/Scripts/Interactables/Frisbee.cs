//--------------------------------------------------------------------------------------
// Purpose: Interaction logic for the frisbee object.
//
// Description: This script will take care of the logic when a frisbee is interacted with
// by the player. This script is to be attached to the frisbee object.
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// Frisbee object. Inheriting from BaseInteractable. The frisbee interactable object.
//--------------------------------------------------------------------------------------
public class Frisbee : BaseInteractable
{
    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private mesh renderer.
    public Renderer m_rRenderer;
    //--------------------------------------------------------------------------------------






    // public transform for where to start the movement lerp.
    public Transform m_tStartPosition;

    // public transform for where to end the movement lerp.
    public Transform m_tEndPosition;

    // public float for the speed of the lerp.
    public float m_fSpeed = 1.0f;

    // private float for when the movement started.
    private float m_fStartTime;

    // private float for the total distance of the journey between start and end.
    private float m_fJourneyLength;








    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    new void Awake()
    {
        // Run the base awake
        base.Awake();

        // Make sure the renderer is enabled
        m_rRenderer.enabled = true;

        

        
        
        
        
        // Start timer
        m_fStartTime = Time.time;

        // Calculate the journey
        m_fJourneyLength = Vector3.Distance(m_tStartPosition.position, m_tEndPosition.position);
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {


        
            
 


        float distCovered = (Time.time - m_fStartTime) * m_fSpeed;
        float fracJourney = distCovered / m_fJourneyLength;
        transform.position = Vector3.Lerp(m_tStartPosition.position, m_tEndPosition.position, fracJourney);

        // set the postion to the postion of the interactable object with a slight offset
        m_psBtnVisual.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);








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

        // disable the mesh
        m_rRenderer.enabled = false;
    }
}