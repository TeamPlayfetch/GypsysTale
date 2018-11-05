using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Menu_Spawner : MonoBehaviour {


    public GameObject player;

    public GameObject[] spawnPoints;
    GameObject chosenSpawn;

	// Use this for initialization
	void Start () {

        RandSpawn();

        Instantiate(player, chosenSpawn.transform.position, chosenSpawn.transform.rotation);

	}

    void RandSpawn()
    {
        chosenSpawn = spawnPoints[Random.Range(0, spawnPoints.Length)] as GameObject;
    }

}
