using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButterflyManager : MonoBehaviour {

	[Header("Butterfly Count")]
	public float maxCount;
	public float currentCount;
	private float butterAdd = 1f;

	[Header("GameObjects")]
	public GameObject winParticle;
	public GameObject player;
	public GameObject allTheButters;
	private GameObject[] getCount;

	[Header("Particles")]
	public ParticleSystem collect;

	[Header("Audio Clips")]
	public AudioClip chew;
	public AudioClip win;
//	public AudioClip lose;
	private AudioSource audioSource;

	[Header ("Timers")]
	public float timeLeft = 30.0f;
//	public float butterCount;

	private bool omNomGo = false;

	public void Start (){
		allTheButters.SetActive (false);
		player = FindObjectOfType<InitalButterfly> ().player;
		audioSource = GetComponent<AudioSource> ();
	}

	public void FixedUpdate (){
		
		if (omNomGo == true) {
			if (currentCount >= maxCount) {
				butterSlaughterWin ();
				omNomGo = false;
			}

			if (omNomGo == true){
				timeLeft = timeLeft - Time.deltaTime;
				if (timeLeft <= 0.0f){
					timeLeft = 0.0f;
				}
			}
			if (timeLeft <= 0.0f && currentCount != maxCount){
				butterSlaughterFail ();
			}

		}

	}

	//start the chase for the butterflies and set the counter
	public void butterSlaughterBegin(){
		getCount = GameObject.FindGameObjectsWithTag ("Butters");
		maxCount = getCount.Length; 
//		Debug.Log ("slaughter go");
		currentCount = 0;
		SpawnButters ();
	}

	//spawn in the butters
	public void SpawnButters (){
		omNomGo = true;
		allTheButters.SetActive (true);
//		Debug.Log ("spawn butters");
		getCount = GameObject.FindGameObjectsWithTag ("Butters");
		maxCount = getCount.Length; 
	}

	//didn't eat all the butterflies
	public void butterSlaughterFail (){
		allTheButters.SetActive (false);
		omNomGo = false;
//		audioSource.PlayOneShot (lose, 1.0f);
	}

	//ate all the butterflies
	public void butterSlaughterWin (){
		Instantiate (winParticle, player.transform.position, Quaternion.identity);
		audioSource.PlayOneShot (win, 1.0f);
		allTheButters.SetActive (false);
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
		if (other.tag == "Butters") {
			GetComponent<ButterflyManager> ().addButter ();
			Instantiate (collect, other.gameObject.transform.position, Quaternion.identity);
			audioSource.PlayOneShot (chew, 1.0f);
//			butterCount = butterCount + 1.0f; 
		}
	}
}
