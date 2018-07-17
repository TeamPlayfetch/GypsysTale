using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesh_Rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.A)) {
			transform.Rotate (0, -90, 0);
		} else
			transform.Rotate (0, 0, 0);

		if (Input.GetKeyDown (KeyCode.D)) {
			transform.Rotate (0, 90, 0);
		} else
			transform.Rotate (0, 0, 0);

		if (Input.GetKeyDown (KeyCode.S)) {
			transform.Rotate (0, 180, 0);
		} else
			transform.Rotate (0, 0, 0);


	}
}
