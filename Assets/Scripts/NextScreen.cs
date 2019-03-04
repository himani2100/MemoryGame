using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScreen : MonoBehaviour
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
        Debug.Log("Play");
        gameObject.SetActive(false);
    }

    public void OnExit()
    {
        Debug.Log("Exit");
        Application.Quit();
        // HAIL GITHUB 
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
