using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
[RequireComponent(typeof(CinemachineFreeLook))]


public class FreeLookUserInput : MonoBehaviour {

	private CinemachineFreeLook freeLookCam;
	// Use this for initialization
	void Start () {
		freeLookCam = GetComponent<CinemachineFreeLook> ();
	}

	// Update is called once per frame
	void Update () {
		freeLookCam.m_XAxis.Value = Input.GetAxis ("RightH");
		freeLookCam.m_YAxis.Value = Input.GetAxis ("RightV");
	}
}
