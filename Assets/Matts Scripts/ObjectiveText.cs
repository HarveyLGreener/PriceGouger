using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI objectiveProgress;
    // Start is called before the first frame update
    public int objectives;
    public int progress;
    void Start()
    {
        objectives = GameObject.FindGameObjectsWithTag("Objective").Length;
    }

    // Update is called once per frame
    void Update()
    {
        objectiveProgress.text = "Objects Priced: " + progress + "/" + objectives + ".";
    }
}
