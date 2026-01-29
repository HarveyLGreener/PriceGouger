using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootPrice : MonoBehaviour
{
	public float MouseSensitivity;
	public Transform CamTransform;
	private float camRotation = 0f;
	[SerializeField] TMP_Text aim;
	[SerializeField] ObjectiveText objective;
	private Color og;

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
		//shoot gun
		if (Input.GetMouseButtonDown(0))
		{
			SimpleRaycast();
		}
		else
        {
			Target();
		}
	}

	private void SimpleRaycast()
	{
		RaycastHit hit;
		if (Physics.Raycast(CamTransform.position, CamTransform.forward, out hit))
		{
			Debug.DrawLine(CamTransform.position + new Vector3(0f, -1f, 0f), hit.point, Color.green, 5f);
			Debug.Log("Simple Raycast: " + hit.collider.gameObject.name);
			if (hit.collider.gameObject.tag == "Objective" || hit.collider.gameObject.tag == "TutorialPriceObjectives")
			{
				hit.collider.gameObject.transform.GetChild(0).gameObject.SetActive(true);
				objective.UpdateProgress();
			}
		}

	}
	private void Target()
	{
		RaycastHit over;
		if (Physics.Raycast(CamTransform.position, CamTransform.forward, out over))
		{
			if (over.collider.gameObject.tag == "Objective" || over.collider.gameObject.tag == "TutorialPriceObjectives")
			{
				aim.color = new Color(0f, 255f, 0f, 255f);
			}
			else if (over.collider.gameObject.tag == "SuperSoakerText" || over.collider.gameObject.tag == "TutorialSuperSoaker")
			{
				aim.color = new Color(0f, 0f, 255f, 255f);
			}
			else
			{
				aim.color = new Color(0f, 0f, 0f, 255f);
			}
		}

	}
}
