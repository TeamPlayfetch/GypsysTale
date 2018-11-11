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
// GypsySpawner object. Inheriting from MonoBehaviour. Randomly spawn gypsy in a 
// different spot every time the menu opens.
//--------------------------------------------------------------------------------------
public class GypsySpawner : MonoBehaviour
{
    // public gameobject for the object to spawn
    [LabelOverride("Gypsy Object")] [Tooltip("The object to be randomly spawned around the scene.")]
    public GameObject m_gGypsy;

    // public array of gamebojects for all the possible spawn points
    [LabelOverride("Spawn Points")] [Tooltip("Place all of the possible spawn points here.")]
    public GameObject[] m_agSpawnPoints;

    // private gameobject for the chosen spawn postion
    private GameObject m_gChosenSpawn;

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    void Awake()
    {
        // decided the chosen spawn point
        m_gChosenSpawn = m_agSpawnPoints[Random.Range(0, m_agSpawnPoints.Length)] as GameObject;

        // instantiate the gypsy object at the chosen spawn point
        Instantiate(m_gGypsy, m_gChosenSpawn.transform.position, m_gChosenSpawn.transform.rotation);
	}
}
