using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	CharacterController charController;
	float movementSpeed = 5f;

	private void Start()
	{
		charController = GetComponent<CharacterController>();

		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () {


		float mouseX = Input.GetAxisRaw("Mouse X");
		float mouseY = Input.GetAxisRaw("Mouse Y");

		transform.Rotate(0f, mouseX, 0f);

		GetComponentInChildren<Camera>().transform.Rotate(-mouseY, 0f, 0f);

		float forwardInput = Input.GetAxisRaw("Vertical");
		float sidewaysInput = Input.GetAxisRaw("Horizontal");

		Vector3 movement = transform.forward * forwardInput + transform.right* sidewaysInput;

		charController.SimpleMove(movement*movementSpeed);


	}
}
