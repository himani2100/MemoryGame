using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Himani Raval
 * 104874756
 */

public class Configurations : MonoBehaviour
{
    public Slider tough; //controls slider
    public Text toughText; //To Tell User the number of superheroes
    public int tougherer = 0; //to manage the pairs of superheroes
    public GameManager savetheworld; //call GameManager

    private void Awake() //cuz they always have to be in pairs
    {
        tougherer = (int)(tough.minValue * 2);
    }

    public void toughORnot(int tougher) //set text
    {
        this.tougherer = (int)(tough.value*2);
        toughText.text = tougherer + " Superheroes";
    }

    public void OnPlay()
    {
        Debug.Log("Battle"); //for debugging purposes
        gameObject.SetActive(false); //stupid thing takes to the next screen
        //Debug.Log(tougherer);
        savetheworld.Battle(tougherer); //let GameManager take over
    }


}
