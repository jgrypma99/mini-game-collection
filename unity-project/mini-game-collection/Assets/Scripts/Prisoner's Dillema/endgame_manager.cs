using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endgame_manager : MonoBehaviour
{
    //timer
    public global_timer globalTimer;

    //float to get the value of the game timer
    float gameTimer;
    
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
        //set game timer to the same value as the timer
        gameTimer = globalTimer.timeRemaining;
        
        //if timer goes below zero set timer to zero
        if (gameTimer < 0)
        {
            gameTimer = 0;
        }
        //once timer hits zero enter the endgame state
        if (gameTimer == 0)
        {
            if (Input.GetButtonDown("P1_Action1") && Input.GetButtonDown("P2_Action1"))
            {
                loss = true;
                Debug.Log("Both lose");
                //Loss event
            }
            else if (Input.GetButtonDown("P1_Action2") && Input.GetButtonDown("P2_Action2"))
            {
                tie = true;
                //Tie event
                Debug.Log("Both tie");
            }
            else if (Input.GetButtonDown("P1_Action1") && Input.GetButtonDown("P2_Action2"))
            {
                p1Win = true;
                //p1Win event
                Debug.Log("P1 Win");
            }
            else if (Input.GetButtonDown("P1_Action2") && Input.GetButtonDown("P2_Action1"))
            {
                p2Win = true;
                //p2Win event
                Debug.Log("P2 Win");
            }
        }
    }
}
