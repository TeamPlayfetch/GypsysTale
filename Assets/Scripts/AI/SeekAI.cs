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



    [HideInInspector]
    public bool m_bWalkingAni;


    private Animator m_aniAnimator;


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

        // Get the animator component of the player
        m_aniAnimator = GetComponentInChildren<Animator>();
    }

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update ()
    {
        // set animation bools in the animator to the bools used in code.
        m_aniAnimator.SetBool("Walking", m_bWalkingAni);

        // set navmesh agent destination to goal position.
        m_nmAgent.destination = m_tGoal.position;








        
        // check if the AI is moving and play animation
        if (m_nmAgent.velocity == new Vector3(0.0f,0.0f,0.0f))
            m_bWalkingAni = false;

        // check if the AI is moving and stop animation
        else
            m_bWalkingAni = true;





    }
}