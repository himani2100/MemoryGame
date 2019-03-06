using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Himani Raval
 * 104874756
 */

public class FinalScreen : MonoBehaviour
{

    public Text score;
    public Text WonOrNot;
    public GameManager obj;
    public Text timeer;
    //The assignment made me do it
    //I wish i had the time stone

    public void Failed(int time)
    {
        timeer.text = "Shawarma place closed at : " + time; //no shawarma for you
        score.text = "Score : 0";
        WonOrNot.text = "Game Over! You were deafeated!"; //Agents of Sheild 
        obj.countscore = 1000; //reset score if they wish to rebattle
    }

    public void Won(int scores, int time)
    {
        timeer.text = "Shawarma served in : " + time; //shawarma for you
        score.text = "Score : " + scores;
        WonOrNot.text = "You deafeated Earth's finest Heroes..."; //Hail Hydra
        obj.countscore = 1000; //reset score if they wish to rebattle
    }
}
