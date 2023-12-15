using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMode : MonoBehaviour
{
    public bool tutorialActive;
    // Start is called before the first frame update
    void Start()
    {
        tutorialActive = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            tutorialActive = false;
        }
    }
}
