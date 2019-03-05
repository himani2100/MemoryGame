using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Himani Raval
 * 104874756
 */

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
            GetComponent<Button>().enabled = false;
            bool returned = winner.Summon(spriterem, this);
            if(!returned)
            {
                getit.sprite = spriterem;
            }

        });

    }

    public void DefeatedHeroes()
    {
        GetComponent<Button>().enabled = false;
    }
}
