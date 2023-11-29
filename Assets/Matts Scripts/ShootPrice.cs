using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPrice : MonoBehaviour
{
	public float MouseSensitivity;
	public Transform CamTransform;
	private float camRotation = 0f;

	private void Start()
	{
		//Locks cursor for mouse movement
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update()
	{
		//Updates direction player is facing based on mouse movement
		float mouseInputY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
		camRotation -= mouseInputY;
		camRotation = Mathf.Clamp(camRotation, -90f, 90f);
		CamTransform.localRotation = Quaternion.Euler(camRotation, 0f, 0f);

		float mouseInputX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
		transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, mouseInputX));

		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("Left Click");
			SimpleRaycast();
		}
	}

	private void SimpleRaycast()
	{
		RaycastHit hit;
		if (Physics.Raycast(CamTransform.position, CamTransform.forward, out hit))
		{
			Debug.DrawLine(CamTransform.position + new Vector3(0f, -1f, 0f), hit.point, Color.green, 5f);
			Debug.Log("Simple Raycast: " + hit.collider.gameObject.name);
			if (hit.collider.gameObject.tag == "Objective")
			{
				hit.collider.gameObject.transform.GetChild(0).gameObject.SetActive(true);
			}
		}

	}
}
