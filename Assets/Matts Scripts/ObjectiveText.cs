using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI objectiveProgress;
    [SerializeField] TextMeshProUGUI superSoakerProgressText;
    // Start is called before the first frame update
    public TutorialMode tutorial;
    public int objectives;
    public int superSoakerObjectives;
    public int tutorialSuperSoakerObjectives;
    public int tutorialPriceObjectives;
    public int progress;
    public int superSoakerProgress;
    public int tutorialPriceProgress;
    public int tutorialSuperSoakerProgress;
    void Start()
    {
        objectives = GameObject.FindGameObjectsWithTag("Objective").Length;
        tutorialPriceObjectives = GameObject.FindGameObjectsWithTag("TutorialPriceObjectives").Length;
        tutorialSuperSoakerObjectives = GameObject.FindGameObjectsWithTag("TutorialSuperSoaker").Length;
        superSoakerObjectives = GameObject.FindGameObjectsWithTag("SuperSoakerText").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(tutorial.tutorialActive)
        {
            objectiveProgress.text = "Objects Priced: " + tutorialPriceProgress + "/" + tutorialPriceObjectives + ".";
            superSoakerProgressText.text = "Objects Soaked: " + tutorialSuperSoakerProgress + "/" + tutorialSuperSoakerObjectives + ".";
        }
        else
        {
            objectiveProgress.text = "Objects Priced: " + progress + "/" + objectives + ".";
            superSoakerProgressText.text = "Objects Soaked: " + superSoakerProgress + "/" + superSoakerObjectives + ".";
        }
    }
}
