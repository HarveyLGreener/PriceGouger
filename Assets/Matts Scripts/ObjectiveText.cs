using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI objectiveProgress;
    [SerializeField] TextMeshProUGUI superSoakerProgressText;
    // Start is called before the first frame update
    public int objectives;
    public int superSoakerObjectives;
    public int progress;
    public int superSoakerProgress;
    void Start()
    {
        objectives = GameObject.FindGameObjectsWithTag("Objective").Length;
        superSoakerObjectives = GameObject.FindGameObjectsWithTag("SuperSoakerText").Length;
    }

    // Update is called once per frame
    void Update()
    {
        objectiveProgress.text = "Objects Priced: " + progress + "/" + objectives + ".";
        superSoakerProgressText.text = "Objects Soaked: " + superSoakerProgress + "/" + superSoakerObjectives + ".";
    }
}
