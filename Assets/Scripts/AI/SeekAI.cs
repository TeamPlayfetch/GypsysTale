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
using UnityEngine.AI;

//--------------------------------------------------------------------------------------
// SeekAI object. Inheriting from MonoBehaviour. 
//--------------------------------------------------------------------------------------
public class SeekAI : MonoBehaviour
{
    // NASHMESH SETTINGS //
    //--------------------------------------------------------------------------------------
    // Title for this section of public values.
    [Header("Navmesh Settings:")]

    // public transform for the goal postion of the ai.
    [LabelOverride("Goal Transform")] [Tooltip("The transform to follow on the navmesh.")]
    public Transform m_tGoal;

    // public foat for the speed of the ai.
    [LabelOverride("Walking Speed")] [Tooltip("The speed that the navmesh will travel around the map.")]
    public float m_fSpeed;

    // Leave a space in the inspector.
    [Space]
    //--------------------------------------------------------------------------------------

    // PRIVATE VALUES //
    //--------------------------------------------------------------------------------------
    // private NavMeshAgent for the navmesh agent of the enemy
    private NavMeshAgent m_nmAgent;
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    void Awake()
    {
        // Get navmesh agent commponent
        m_nmAgent = GetComponent<NavMeshAgent>();

        // set speed to the navmesh agent
        m_nmAgent.speed = m_fSpeed;
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update ()
    {
        // set navmesh agent destination to goal position.
        m_nmAgent.destination = m_tGoal.position;
    }
}