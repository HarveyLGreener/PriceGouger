using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController CC;
	public float MoveSpeed = 10.0f;
	public float SpeedMultiplier = 1.0f;
	public float Gravity = -9.8f;
	public float JumpSpeed;

	private void Update()
	{
		Vector3 movement = Vector3.zero;

		// X/Z movement
		float forwardMovement = Input.GetAxis("Vertical") * MoveSpeed * SpeedMultiplier * Time.deltaTime;
		float sideMovement = Input.GetAxis("Horizontal") * MoveSpeed * SpeedMultiplier * Time.deltaTime;

		movement += (transform.forward * forwardMovement) + (transform.right * sideMovement);

		CC.Move(movement);

		if(Input.GetKeyDown(KeyCode.LeftShift))
        {
			Sprint(5.0f);
        }
		else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
			SpeedMultiplier = 1.0f;
        }
	}

	public void Sprint(float multiplier)
    {
		SpeedMultiplier = multiplier;
    }
}
