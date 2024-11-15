using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class global_timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeRemaining = 30f;
    // Update is called once per frame
    void Update()
    {
        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = timeRemaining.ToString();
            //if timer ever goes below zero for whatever reason set it to zero
            if (timeRemaining < 0)
            { 
                timeRemaining = 0; 
            }
        }
    }
}
