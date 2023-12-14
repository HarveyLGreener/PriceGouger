using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TImer : MonoBehaviour
{
    public float timer;
    public ObjectiveText goal;
    public FMOD.Studio.EventInstance parameter;
    [FMODUnity.EventRef]
    public string fmodEvent;
    public float fulltime;
    public FMODUnity.StudioEventEmitter emitter;
    [SerializeField] TextMeshProUGUI countdown;
    [SerializeField] TextMeshProUGUI outcome;
    // Start is called before the first frame update
    void Start()
    {
        parameter = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        parameter.start();
        fulltime = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if ((timer >= 0f) & (goal.progress < goal.objectives))
        {
            timer -= Time.deltaTime;
            int timeLeft = (int)Mathf.Round(timer);
            countdown.text = timeLeft.ToString();
        }
        else if ((goal.progress >= goal.objectives)&(goal.superSoakerProgress >= goal.superSoakerObjectives)&(timer>0f))
        {
            outcome.text = "You Win!";
        }
        else
        {
            outcome.text = "You Lost!";
        }
        parameter.setParameterByName("LevelPercentage", (-1*(timer-fulltime)/fulltime));
        if (((int)Mathf.Round(timer)%20==0) && (!emitter.IsPlaying()))
        {
            emitter.Play();
        }
        if(emitter.IsPlaying())
        {
            parameter.setParameterByName("ManagerTalking", 0);
        }
        else
        {
            parameter.setParameterByName("ManagerTalking", 1);
        }
    }
}
