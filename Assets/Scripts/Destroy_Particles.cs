using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Particles : MonoBehaviour {

	IEnumerator Start(){
		yield return new WaitForSeconds (GetComponent<ParticleSystem> ().duration + 1.0f);
		Destroy (gameObject);
	}
}
