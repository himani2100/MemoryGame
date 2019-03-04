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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Failed()
    {
        score.text = "Score : 0";
    }
}
