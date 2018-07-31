using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButterflyManager : MonoBehaviour {

	[Header("Butterfly Count")]
	public float maxCount;
	public float currentCount;
	private float butterAdd = 1f;

	[Header("Images")]
	public Image buttersImage;

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
	private AudioSource audioSource;

//	public float butterCount;


	private bool omNomGo;

	public void Start (){
		buttersImage.enabled = false;
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
		}

		//need to add in a timer and do a check for the timer finishing but the count not reaching the max number. 
		//if it does, then run butterSlaughterFail
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
		buttersImage.enabled = true;
	}

	//didn't eat all the butterflies
	public void butterSlaughterFail (){
		allTheButters.SetActive (false);
	}

	//ate all the butterflies
	public void butterSlaughterWin (){
		Instantiate (winParticle, transform.position, Quaternion.identity);
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
		if (other.tag == "Butters" && (Input.GetKeyDown(KeyCode.E))) {
			GetComponent<ButterflyManager> ().addButter ();
			Instantiate (collect, other.gameObject.transform.position, Quaternion.identity);
			audioSource.PlayOneShot (chew, 1.0f);
//			butterCount = butterCount + 1.0f; 
		}
	}
}
