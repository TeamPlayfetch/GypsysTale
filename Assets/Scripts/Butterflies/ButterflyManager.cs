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


	private bool omNomGo;

	public void Start (){
		getCount = GameObject.FindGameObjectsWithTag ("Butters");
		maxCount = getCount.Length; 
		buttersImage.enabled = false;
		allTheButters.SetActive (false);
	}

	public void FixedUpdate (){
		if (currentCount >= maxCount) {
			butterSlaughterWin ();

		}

		//need to add in a timer and do a check for the timer finishing but the count not reaching the max number. 
		//if it does, then run butterSlaughterFail
	}

	//start the chase for the butterflies and set the counter
	public void butterSlaughterBegin(){
		getCount = GameObject.FindGameObjectsWithTag ("Butters");
		maxCount = getCount.Length; 
		Debug.Log ("slaughter go");
		currentCount = 1;
		SpawnButters ();
	}

	//spawn in the butters
	public void SpawnButters (){
		omNomGo = true;
		allTheButters.SetActive (true);
		Debug.Log ("spawn butters");
		buttersImage.enabled = true;
	}

	//didn't eat all the butterflies
	public void butterSlaughterFail (){
		allTheButters.SetActive (false);
	}

	//ate all the butterflies
	public void butterSlaughterWin (){
		Debug.Log ("WIN");
	}

	// adding a butterfly to the count
	public void addButter(){
		if (omNomGo == true) {
			currentCount = currentCount + 1;
			return;
		}
	}
}
