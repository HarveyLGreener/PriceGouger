using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseSensitivityControl : MonoBehaviour
{
    public ShootPrice shootPrice;
    public TMP_Text mouseSensitivityText;

    void Start()
    {
        shootPrice = GetComponent<ShootPrice>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            changeMouseSensitivity(10);
            Debug.Log("Increase mouse sensitivity");
        }
        else if (Input.GetKeyDown(KeyCode.Minus))
        {
            changeMouseSensitivity(-10);
            Debug.Log("Decrease mouse sensitivity");
        }
        else if(Input.GetKeyDown(KeyCode.M))
        {
            if(mouseSensitivityText.gameObject.activeSelf)
            {
                showMouseSensitivityText(false);
            }
            else
            {
                showMouseSensitivityText(true);
            }
        }

        mouseSensitivityText.SetText("Press + or - to Change Mouse Sensitivity\nPress M to Toggle Visibility of This Text\nMouse Sensitivity: " + shootPrice.MouseSensitivity);
    }

    private void showMouseSensitivityText(bool visible)
    {
        if (visible)
        {
            mouseSensitivityText.gameObject.SetActive(true);
        }
        else
        {
            mouseSensitivityText.gameObject.SetActive(false);
        }
    }

    private void changeMouseSensitivity(int amount)
    {
        shootPrice.MouseSensitivity += amount;
    }
}
