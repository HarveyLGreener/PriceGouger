using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMode : MonoBehaviour
{
    public bool tutorialActive;
    public ObjectiveText objectiveText;
    
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
            objectiveText.progress = 0;

            foreach (GameObject priceObjective in GameObject.FindGameObjectsWithTag("TutorialPriceObjectives"))
            {
                Destroy(priceObjective);
            }

            foreach (GameObject superSoaker in GameObject.FindGameObjectsWithTag("TutorialSuperSoaker"))
            {
                Destroy(superSoaker);
            }

            foreach (GameObject tutorialText in GameObject.FindGameObjectsWithTag("TutorialArea"))
            {
                Destroy(tutorialText);
            }
        }
    }
}
