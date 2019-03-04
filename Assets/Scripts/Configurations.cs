using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Configurations : MonoBehaviour
{
    public Slider tough;
    public Text toughText;
    public int tougherer = 0;
    public GameManager savetheworld;

    private void Awake()
    {
        tougherer = (int)(tough.minValue * 2);
    }

    public void toughORnot(int tougher)
    {
        this.tougherer = (int)(tough.value*2);
        toughText.text = tougherer + " Superheroes";
    }

    public void OnPlay()
    {
        Debug.Log("Battle");
        gameObject.SetActive(false); //stupid thing takes to the next screen
        //Debug.Log(tougherer);
        savetheworld.Battle(tougherer);
    }


}
