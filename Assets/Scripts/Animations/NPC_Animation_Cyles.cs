using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Animation_Cyles : MonoBehaviour {


    public int aniIdleCycle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RandomCycle();
	}

    public void RandomCycle()
    {
        aniIdleCycle = Random.Range(1, 4);
    }

}
