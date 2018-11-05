using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;
using XInputDotNetPure;

public class Butterfly1 : MonoBehaviour {

	public XboxController xControl;

	public GameObject player;


	private bool started;

	public void Start (){
		started = true;
	}

	public void FixedUpdate (){

	}

	public void OnTriggerEnter (Collider other){
		//		if (other.tag == "Player" && (XCI.GetButtonDown(XboxButton.B) && started == false)) {
		//			started = true;
		//		}
		if (other.tag == "Player" && started == true) {
//			(other.tag == "Player" && (Input.GetButtonDown("Interact") && started == true))
//			Debug.Log ("monch");
			Destroy (this.gameObject);
		}

		//		if (other.tag == "Player") {
		//			Destroy (this.gameObject);
		//		}
	}
}
