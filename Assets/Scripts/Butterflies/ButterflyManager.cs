using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButterflyManager : MonoBehaviour {

	private GameObject[] getCount;
	public float maxCount;
	public float currentCount;
	public GameObject allTheButters;
	public Image buttersImage;
	private float butterAdd = 1f;

	public GameObject winParticle;
	public GameObject player;

//	public float butterCount;


	private bool omNomGo;

	public void Start (){
		
		buttersImage.enabled = false;
		allTheButters.SetActive (false);

		player = FindObjectOfType<InitalButterfly> ().player;
	}

	public void FixedUpdate (){
		if (omNomGo == true) {
			if (currentCount >= maxCount) {
				butterSlaughterWin ();
				omNomGo = false;
			}
		}

		//need to add in a timer and do a check for the timer finishing but the count not reaching the max number. 
		//if it does, then run butterSlaughterFail
	}

	//start the chase for the butterflies and set the counter
	public void butterSlaughterBegin(){
		getCount = GameObject.FindGameObjectsWithTag ("Butters");
		maxCount = getCount.Length; 
//		Debug.Log ("slaughter go");
		currentCount = 1;
		SpawnButters ();
	}

	//spawn in the butters
	public void SpawnButters (){
		omNomGo = true;
		allTheButters.SetActive (true);
//		Debug.Log ("spawn butters");
		getCount = GameObject.FindGameObjectsWithTag ("Butters");
		maxCount = getCount.Length; 
		buttersImage.enabled = true;
	}

	//didn't eat all the butterflies
	public void butterSlaughterFail (){
		allTheButters.SetActive (false);
	}

	//ate all the butterflies
	public void butterSlaughterWin (){
		Instantiate (winParticle, player.transform.position, player.transform.rotation);
//		Debug.Log ("WIN");
		return;
	}

	// adding a butterfly to the count
	public void addButter(){
		if (omNomGo == true) {
			currentCount = currentCount + butterAdd;
			return;
		}
	}
		
	public void OnTriggerEnter (Collider other){
		if (other.tag == "Butters" && (Input.GetKeyDown(KeyCode.E))) {
			GetComponent<ButterflyManager> ().addButter ();
//			butterCount = butterCount + 1.0f; 
		}
	}
}
