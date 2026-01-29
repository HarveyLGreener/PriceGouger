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
    [SerializeField] SceneChange changeScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!tutorial.tutorialActive)
        {
            if ((timer >= 0f) & (goal.progress < goal.objectives))
            {
                timer -= Time.deltaTime;
                int timeLeft = (int)Mathf.Round(timer);
                countdown.text = timeLeft.ToString();
            }
            else if ((goal.progress >= goal.objectives) & (goal.superSoakerProgress >= goal.superSoakerObjectives) & (timer > 0f))
            {
                changeScene.LoadScene("WinScreen");
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                changeScene.LoadScene("LoseScreen");
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            countdown.text = "Tutorial";
        }
    }
}
