using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Himani Raval
 * 104874756
 */

public class NextScreen : MonoBehaviour //more like intro screen
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlay() 
    {
        Debug.Log("Play"); //for debugging purposes
        gameObject.SetActive(false); //take to next screen
    }

    public void OnExit()
    {
        Debug.Log("Exit"); //for debugging purposes
        Application.Quit();
        // HAIL GITHUB 
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
