using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endgame_manager : MonoBehaviour
{
    //int to get the value of the game timer
    int globalTimer;
    
    //various endgame states
    bool p1Win;
    bool p2Win;
    bool tie;
    bool loss;

    // Update is called once per frame
    /* Actions
       P1_Action1 = player one poison
       P1_Action2 = player one cooperate
       P2_Action1 = player two poison
       P2_Action2 = player two cooperate
     */
    void Update()
    {
        //if timer goes below zero set timer to zero
        if (globalTimer < 0)
        {
            globalTimer = 0;
        }
        //once timer hits zero enter the endgame state
        if (globalTimer == 0)
        {
            if (Input.GetButtonDown("P1_Action1") && Input.GetButtonDown("P2_Action1"))
            {
                loss = true;
                //Loss event
            }
            else if (Input.GetButtonDown("P1_Action2") && Input.GetButtonDown("P2_Action2"))
            {
                tie = true;
                //Tie event
            }
            else if (Input.GetButtonDown("P1_Action1") && Input.GetButtonDown("P2_Action2"))
            {
                p1Win = true;
                //p1Win event
            }
            else if (Input.GetButtonDown("P1_Action2") && Input.GetButtonDown("P2_Action1"))
            {
                p2Win = true;
                //p2Win event
            }
        }
    }
}
