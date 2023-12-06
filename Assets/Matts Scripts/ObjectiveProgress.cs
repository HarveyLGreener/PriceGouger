using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveProgress : MonoBehaviour
{
    [SerializeField] ObjectiveText objectiveText;
    private void Awake()
    {
        objectiveText.progress += 1;
    }

}
