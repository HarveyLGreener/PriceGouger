using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SuperSoaker : MonoBehaviour
{
	public Transform CamTransform;
	public TutorialMode tutorial;
	[SerializeField] ObjectiveText superSoakerObjectiveText;
	[SerializeField] private float superSoakerSpeed;

	void Update()
    {
		if (Input.GetMouseButton(1))
		{
			Debug.Log("Right Click");
			SoakSign();
		}

	}

	private void SoakSign()
	{
		RaycastHit hit;
		if (Physics.Raycast(CamTransform.position, CamTransform.forward, out hit))
		{
			Debug.DrawLine(CamTransform.position + new Vector3(0f, -1f, 0f), hit.point, Color.green, 5f);
			Debug.Log("Simple Raycast: " + hit.collider.gameObject.name);
			if (hit.collider.gameObject.tag == "SuperSoakerText" || hit.collider.gameObject.tag == "TutorialSuperSoaker")
			{
				TextMeshPro superSoakerText = hit.collider.gameObject.GetComponent<TextMeshPro>();
				superSoakerText.color = new Color(superSoakerText.color.r, superSoakerText.color.g, superSoakerText.color.b, superSoakerText.color.a - superSoakerSpeed);
				if(superSoakerText.color.a <= 0.0f)
                {
					if(!tutorial.tutorialActive)
                    {
						superSoakerObjectiveText.superSoakerProgress++;
					}
					else
                    {
						superSoakerObjectiveText.tutorialSuperSoakerProgress++;
                    }
					
					hit.collider.gameObject.tag = "Untagged";
				}					
			}
		}
	}
}
