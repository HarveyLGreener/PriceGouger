using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TImer : MonoBehaviour
{
    public TutorialMode tutorial;
    public float timer;
    public ObjectiveText goal;
    [SerializeField] TextMeshProUGUI countdown;
    [SerializeField] TextMeshProUGUI outcome;
    public FMOD.Studio.EventInstance parameter;
    [FMODUnity.EventRef]
    public string fmodEvent0;
    public string fmodEvent1;
    public float fulltime;
    public FMODUnity.StudioEventEmitter emitter;
    public FMOD.Studio.EventInstance tutorialmusic;
    // Start is called before the first frame update
    void Start()
    {
        parameter = FMODUnity.RuntimeManager.CreateInstance(fmodEvent1);
        tutorialmusic = FMODUnity.RuntimeManager.CreateInstance(fmodEvent0);
        tutorialmusic.start();
        fulltime = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (!tutorial.tutorialActive)
        {
            if((int)Mathf.Round(timer)==fulltime-1)
            {
                tutorialmusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                parameter.start();
            }
            if ((timer >= 0f) & ((goal.progress < goal.objectives) || (goal.superSoakerProgress < goal.superSoakerObjectives)))
            {
                timer -= Time.deltaTime;
                int timeLeft = (int)Mathf.Round(timer);
                countdown.text = timeLeft.ToString();
            }
            else if ((goal.progress >= goal.objectives) & (goal.superSoakerProgress >= goal.superSoakerObjectives) & (timer > 0f))
            {
                outcome.text = "You Win!";
            }
            else if (timer < 0f)
            {
                outcome.text = "You Lost!";
            }
        }
        else
        {
            countdown.text = "Tutorial";
        }
        parameter.setParameterByName("LevelPercentage", (-1 * (timer - fulltime) / fulltime));
        if (((int)Mathf.Round(timer) % 20 == 0) && (!emitter.IsPlaying()))
        {
            emitter.Play();
        }
        if (emitter.IsPlaying())
        {
            parameter.setParameterByName("ManagerTalking", 0);
        }
        else
        {
            parameter.setParameterByName("ManagerTalking", 1);
        }
    }
}
