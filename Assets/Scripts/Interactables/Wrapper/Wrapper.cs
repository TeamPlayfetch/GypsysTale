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

    // public gameobject for the end node of the trail
    [LabelOverride("Hotdog Stand")]
    [Tooltip("This is the end node of the trail, drag on the hotdog stand and make sure it has a large sphere trigger for when the player gets near.")]
    public GameObject m_gEndNode;

    // public gameobject for the hotdog object
    [LabelOverride("Hotdog Object")] [Tooltip("The hotdog object that the player collects at the end of the wrapper mini-game.")]
    public GameObject m_gHotDogObject;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private list of gameobjects for the wrapper nodes.
    private List<GameObject> m_agNodes = new List<GameObject>();

    // private bool for checking the player collsion.
    private bool m_bPlayerCollision = false;
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
        // Check if the player has triggered the hotdog stand collison box.
        m_gEndNode.GetComponent<HotdogStand>().HotdogStandTriggerCallback += () => m_bPlayerCollision = true;

        // player collides with end node.
        if (m_bPlayerCollision && m_bInteracted)
        {
            // for each of the nodes in the array.
            for (int i = 0; i < m_agNodes.Count; i++)
            {
                // set node inactive.
                m_agNodes[i].SetActive(false);

                // disable the script after use
                this.enabled = false;
            }
        }

        // if the wrapper hasnt been interacted with yet
        if (!m_bInteracted)
        {
            // player collison is false
            m_bPlayerCollision = false;
        }
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
            // set node active.
            m_agNodes[i].SetActive(true);
        }

        // set the hotdog object at the hotdog stand to active
        m_gHotDogObject.SetActive(true);
    }
}