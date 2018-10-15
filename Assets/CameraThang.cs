using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraThang : MonoBehaviour {

	public GameObject camera1;
	public GameObject camera2;
	bool fade;
	private Animator fadeAnim;
	public Image fadeIn;

	void Start(){
		camera2.SetActive (false);
		fadeAnim = fadeIn.GetComponent<Animator> ();
		fade = false;
	}

	public void FixedUpdate(){
		fadeAnim.SetBool ("Fade", fade);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") 
		{
			camera1.SetActive (false);
			camera2.SetActive (true);
			fade = true;
		}


	}



}
