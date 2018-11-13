//--------------------------------------------------------------------------------------
// Purpose:
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
// HumanParent object. Inheriting from MonoBehaviour. Main script for the Human Parent.
//--------------------------------------------------------------------------------------
public class HumanParent : MonoBehaviour
{
    // PUBLIC HIDDEN //
    //--------------------------------------------------------------------------------------
    // public hidden bool for if the child has been returned
    [HideInInspector]
    public bool m_bChildReturned = false;
    //--------------------------------------------------------------------------------------

    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // the AIseek script attached to this object
    private SeekAI m_sSeekScript;

    // private bool for when to fade out the mesh
    private bool m_bFadeOut = false;
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    void Awake()
    {
        // get the component for the seek script
        m_sSeekScript = GetComponent<SeekAI>();
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {
        // start fade out for material
        if (m_bFadeOut)
        {
            // destory the gameobject
            Destroy(gameObject);
        }
    }

    //--------------------------------------------------------------------------------------
    // OnTriggerEnter: OnTriggerEnter is called when the Collider cObject enters the trigger.
    //
    // Param:
    //      cObject: The other Collider invloved in the collision.
    //--------------------------------------------------------------------------------------
    private void OnTriggerEnter(Collider cObject)
    {
        // if collides is lost child
        if (cObject.tag == "Child")
        {
            // child return is true
            m_bChildReturned = true;

            // enabled the seek script for the AI
            m_sSeekScript.enabled = true;
        }

        // if collides is end point
        if (cObject.tag == "AIEnd")
        {
            // start fade out of material
            m_bFadeOut = true;
        }
    }
}