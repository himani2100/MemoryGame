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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Failed(int time)
    {

        timeer.text = "Shawarma place closed at : " + time;
        score.text = "Score : 0";
        WonOrNot.text = "Game Over! You were deafeated!";
        obj.countscore = 1000;
    }

    public void Won(int scores, int time)
    {
        timeer.text = "Shawarma served in : " + time;
        score.text = "Score : " + scores;
        WonOrNot.text = "You deafeated Earth's finest Heroes...";
        obj.countscore = 1000;
    }
}
