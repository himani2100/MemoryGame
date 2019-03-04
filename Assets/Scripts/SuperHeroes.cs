using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperHeroes : MonoBehaviour
{
    public Sprite thing
    {
        set
        {
            GetComponent<Image>().sprite = value;
        }
    }

    public void match(Sprite spriterem, GameManager winner)
    {
        var getit = GetComponent<Image>();

        GetComponent<Button>().onClick.AddListener(() =>
        {
         
            winner.Summon(spriterem, this);
            getit.sprite = spriterem;
        });

    }

    public void DefeatedHeroes()
    {
        GetComponent<Button>().enabled = false;
    }
}
