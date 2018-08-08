using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTasks : MonoBehaviour {
	// gameobject that the tasks are attached to
		public GameObject tasksUI;
	//amimator that the tasks are animated with
		private Animator tasksAnim;
	//bool to turn off and on the task UI
		public bool UION;

	public GameObject thoughtBubble;

	public GameObject thoughtTrail;


	// Use this for initialization
	void Start () {
		
		tasksAnim = tasksUI.GetComponent<Animator> ();
		thoughtBubble.SetActive (false);
		thoughtTrail.SetActive (false);
		UION = false;
	

		}
		
// Update is called once per frame
void FixedUpdate () {

		tasksAnim.SetBool ("UION", UION);
		// Hold shift to keep UI on
		if (Input.GetButtonDown("To Do List")) {

			UION = true;

		}
		if (Input.GetButtonUp("To Do List")) {

			UION = false;

		}
		if (Input.GetButtonDown("To Do List")) {
			thoughtBubble.SetActive (true);
			thoughtTrail.SetActive (true);
		}
		if (Input.GetButtonUp("To Do List")) {
			thoughtBubble.SetActive (false); 
			thoughtTrail.SetActive (false); 

		}
	}

					
}



