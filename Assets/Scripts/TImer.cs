using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TImer : MonoBehaviour
{
    public float timer;
    public ObjectiveText goal;
    [SerializeField] TextMeshProUGUI countdown;
    [SerializeField] TextMeshProUGUI outcome;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            int timeLeft = (int)Mathf.Round(timer);
            countdown.text = timeLeft.ToString();
        }
        else
        {
            outcome.text = "You Lost!";
        }
    }
}
