using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveProgress : MonoBehaviour
{
    [SerializeField] ObjectiveText objectiveText;
    private void Awake()
    {
        objectiveText.progress += 1;
        Debug.Log("I am an active script!");
        if(objectiveText.tutorialPriceProgress < objectiveText.tutorialPriceObjectives)
        {
            objectiveText.tutorialPriceProgress++;
            Debug.Log("Update tutorial");
        }
    }

}
