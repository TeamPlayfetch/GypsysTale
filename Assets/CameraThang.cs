using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraThang : MonoBehaviour {

	public GameObject camera1;
	public GameObject camera2;

	void Start(){
		camera2.SetActive (false);

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") 
		{
			camera1.SetActive (false);
			camera2.SetActive (true);

		}


	}



}
