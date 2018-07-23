using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Player_Movement : MonoBehaviour {

	public float moveSpeed = 10.0f;
	public float jumpForce = 8.0f;
	public float gravity = 30.0f;
	public float rotSpeed = 3.0f;

	private Vector3 moveDir = Vector3.zero;
	private CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = gameObject.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (controller.isGrounded){
			moveDir = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

			moveDir = transform.TransformDirection (moveDir);

			moveDir *= moveSpeed;

			if(Input.GetKeyDown(KeyCode.Space)){
				moveDir.y = jumpForce;
			}
		}

	

//		if (moveDir != Vector3.zero){
//			transform.rotation = Quaternion.Slerp (transform.rotation, 
//				Quaternion.LookRotation (moveDir), Time.deltaTime * rotSpeed);
//		}

		moveDir.y -= gravity * Time.deltaTime;

		controller.Move (moveDir * Time.deltaTime);

	}
}
