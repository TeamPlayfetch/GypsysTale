﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoneScore : MonoBehaviour {
	//Total Score
	public float boneCounter;
	//Where the count is displayed 
	public Text boneCount;
	// amount of points per bone collected
	public float boneAdd = 1f;

	public GameObject textActive;

	public float boneScore = 0.0f;
	// Use this for initialization
	void Start () {
		textActive.SetActive (false);
	}
		
	// Update is called once per frame
	void Update () {

		boneCount.text = ((int)boneScore).ToString ();
	}
		public void OnTriggerEnter (Collider other){
			if (other.tag == "Bone"){
			boneScore += boneAdd;
			textActive.SetActive (true);
			StartCoroutine (BoneTime ());
		} else {
			textActive.SetActive (false);
		}
	}

	IEnumerator BoneTime(){
		yield return new WaitForSecondsRealtime (5);
	}
}
