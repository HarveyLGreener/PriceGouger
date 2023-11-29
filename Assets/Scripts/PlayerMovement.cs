using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController CC;
	public float MouseSensitivity;
	public Transform CamTransform;
	public float MoveSpeed = 10.0f;
	public float SpeedMultiplier = 1.0f;
	public float Gravity = -9.8f;
	public float JumpSpeed;

	public float CamRotation;
	public float VerticalSpeed;
	
	private void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update()
	{
		Vector3 movement = Vector3.zero;

		// X/Z movement
		float forwardMovement = Input.GetAxis("Vertical") * MoveSpeed * SpeedMultiplier * Time.deltaTime;
		float sideMovement = Input.GetAxis("Horizontal") * MoveSpeed * SpeedMultiplier * Time.deltaTime;

		movement += (transform.forward * forwardMovement) + (transform.right * sideMovement);

		CC.Move(movement);

		float mouseInputY = Input.GetAxis("Mouse Y") * MouseSensitivity;
		CamRotation -= mouseInputY;
		CamRotation = Mathf.Clamp(CamRotation, -90f, 90f);
		CamTransform.localRotation = Quaternion.Euler(new Vector3(CamRotation, 0f, 0f));

		float mouseInputX = Input.GetAxis("Mouse X") * MouseSensitivity;
		transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, mouseInputX, 0f));

	}
}
