using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class global_timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject timer;
    public GameObject rules;
    public float timeRemaining = 30f;
    bool startState;

    private void Start()
    {
        startState = true;
        timer.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("P1_Action1") || Input.GetButtonDown("P2_Action1") || Input.GetButtonDown("P1_Action2") || Input.GetButtonDown("P2_Action2"))
        {
            startState = false;
            timer.SetActive(true);
        }

        if (startState == false)
        {
            rules.SetActive(false);
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.fixedDeltaTime;
                timerText.text = timeRemaining.ToString();               
            }
            //if timer ever goes below zero for whatever reason set it to zero
            if (timeRemaining < 0)
            {
                timeRemaining = 0;
            }
        }
    }
}
