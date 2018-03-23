using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	public float speed = 10.0f;
	public float forceJump = 2.0f;
	public float gravity = 14.0f;
	public float jumpForce = 10.0f;
	public float verticalVelocity;
	public CharacterController controller;

	void Start () {
		
		Cursor.lockState = CursorLockMode.Locked;
		controller = GetComponent<CharacterController> ();

	}

	void Update () {

		if (Input.GetKeyDown ("escape"))
			Cursor.lockState = CursorLockMode.None;

		if (controller.isGrounded) {

			verticalVelocity = -gravity * Time.deltaTime;

			if (Input.GetKeyDown (KeyCode.Space)) {
				verticalVelocity = jumpForce;
			}

		} 
		else {
			verticalVelocity -= gravity * Time.deltaTime;
		}

		Vector3 moveVector = Vector3.zero;
		moveVector.x = Input.GetAxis ("Horizontal")*5.0f;
		moveVector.y = verticalVelocity;
		moveVector.z = Input.GetAxis("Vertical") * 5.0f;
		controller.Move (moveVector * Time.deltaTime);			
		
	}
}
