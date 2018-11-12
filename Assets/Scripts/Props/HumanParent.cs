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





    [HideInInspector]
    public bool m_bChildReturned = false;





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
        }
    }
}