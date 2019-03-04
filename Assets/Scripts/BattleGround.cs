using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Himani Raval
 * 104874756
 */

public class BattleGround : MonoBehaviour
{
    public Text Minutes;
    public Text highScore;
    public FinalScreen obj;

    /*public Text Seconds;
    public Text totalMinutes;
    public Text totalSeconds;*/

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "1000";
    }

    // Update is called once per frame
    void Update()
    {
        var curtime = Time.time;
        Minutes.text = curtime.ToString();
    }

    public void SetScore(int newscore)
    {
        if(newscore <= 0)
        {
            gameObject.SetActive(false);
            obj.Failed();
        }

        else
        {
            highScore.text = newscore.ToString();
        }

    }
}
