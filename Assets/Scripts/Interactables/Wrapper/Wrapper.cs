//--------------------------------------------------------------------------------------
// Purpose: The wrapper script for hot dog trail mini-game.
//
// Description: This script is used for the hot dog wrapper object. This script is to be 
// attached to the hot dog wrapper object.
//
// Author: Thomas Wiltshire
//--------------------------------------------------------------------------------------

// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------------
// Wrapper object. Inheriting from BaseInteractable. Main class for the hot dog wrapper 
// used for particle trail mini game / objective.
//--------------------------------------------------------------------------------------
public class Wrapper : BaseInteractable
{
    // NODES //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Nodes:")]

    // public gameobject for the node container
    [LabelOverride("Node Container")] [Tooltip("The Empty parent objects that contains all of the nodes.")]
    public GameObject m_gNodeContainer;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------





    public GameObject m_gEndPoint;





    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private list of gameobjects for the wrapper nodes.
    private List<GameObject> m_agNodes = new List<GameObject>();
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    new void Awake()
    {
        // Run the base awake
        base.Awake();
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {





        //// for each child in the nodes array
        //for (int i = 0; i < m_agNodes.Count; i++)
        //{
        //    // set node inactive.
        //    m_agNodes[i].SetActive(true);
        //}




    }

    //--------------------------------------------------------------------------------------
    // InteractedWith: override function from base class for what Interactable objects do 
    // once they have been interacted with.
    //--------------------------------------------------------------------------------------
    protected override void InteractedWith()
    {
        // Run the base interactedWith function.
        base.InteractedWith();

        // for each of the children in the node container
        for (int i = 0; i < m_gNodeContainer.transform.childCount; ++i)
        {
            // Add each child to the nodes array
            m_agNodes.Add(m_gNodeContainer.transform.GetChild(i).gameObject);
        }

        // for each child in the nodes array
        for (int i = 0; i < m_agNodes.Count; i++)
        {
            // set node inactive.
            m_agNodes[i].SetActive(true);
        }
    }
}