using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController CC;
	public float MoveSpeed = 10.0f;
	public float SpeedMultiplier = 1.0f;
	public float Gravity = -9.8f;
	public float JumpSpeed = 10f;
	public bool hasLanded = true;
	public float verticalSpeed;
	public FMODUnity.StudioEventEmitter emitter;
	public FMODUnity.StudioEventEmitter sprint;
	[SerializeField] GameObject sprintlines;

	private void Update()
	{
		Vector3 movement = Vector3.zero;

		// X/Z movement
		float forwardMovement = Input.GetAxis("Vertical") * MoveSpeed * SpeedMultiplier * Time.deltaTime;
		float sideMovement = Input.GetAxis("Horizontal") * MoveSpeed * SpeedMultiplier * Time.deltaTime;

		movement += (transform.forward * forwardMovement) + (transform.right * sideMovement);
		if (CC.isGrounded)
		{
			verticalSpeed = 0f;
			hasLanded = true;
		}
		if ((Input.GetKeyDown(KeyCode.Space)) & (-0.6 < verticalSpeed) & (verticalSpeed <= 0f) & (hasLanded == true))
		{
			hasLanded = false;
			verticalSpeed = JumpSpeed;
		}

		verticalSpeed += (Gravity * Time.deltaTime);
		movement += (transform.up * verticalSpeed * Time.deltaTime);


		CC.Move(movement);

		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			Sprint(2.0f);
		}
		else if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			SpeedMultiplier = 1.0f;
			sprint.Stop();
			sprintlines.SetActive(false);
		}

		if ((hasLanded == true) && ((sideMovement != 0) || (forwardMovement != 0)))
		{

			if (!emitter.IsPlaying())
			{
				emitter.Play();
			}
		}
		else
		{
			emitter.Stop();
		}
	}

	public void Sprint(float multiplier)
	{

		SpeedMultiplier = multiplier;
		if (!sprint.IsPlaying())
		{
			sprint.Play();
		}
		sprintlines.SetActive(true);
	}
}
