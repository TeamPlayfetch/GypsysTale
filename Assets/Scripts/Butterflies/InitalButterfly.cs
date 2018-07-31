using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;
using XInputDotNetPure;

public class InitalButterfly : MonoBehaviour {

	public XboxController xControl;

	public GameObject player;

	private bool started;

	public void Start (){
		started = false;
		}

	public void FixedUpdate (){
		
	}

	public void OnTriggerEnter (Collider other){
//		if (other.tag == "Player" && (XCI.GetButtonDown(XboxButton.B) && started == false)) {
//			started = true;
//		}
		if (other.tag == "Player" && (Input.GetKeyDown(KeyCode.E) && started == false)) {
			started = true;
			gameObject.SetActive (false);
//			Debug.Log ("monch");
//			Destroy (this.gameObject);
			player.GetComponent<ButterflyManager> ().butterSlaughterBegin ();
		}

//		if (other.tag == "Player") {
//			Destroy (this.gameObject);
//		}
	}
}
