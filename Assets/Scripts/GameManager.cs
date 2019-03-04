using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public SuperHeroes prething;
    public Transform gridlaid;
    public Sprite cardback;
    public Sprite check;
    public SuperHeroes hero1, hero2;

    public List<Sprite> cards = new List<Sprite>();

    public void Battle(int tough)
    {
        //Debug.Log(tough); //fine
        List<int> heroesindex = new List<int>();
        List<Sprite> heroes = new List<Sprite>();
        //Debug.Log(heroes.Count);
        int random = 0, index = 0;

        foreach (Transform thing in gridlaid)
        {
            Debug.Log("Hi");
            Destroy(thing.gameObject);
        }

        Debug.Log(cards.Count);
        for (int j = 0; j < cards.Count; j++)
        {
            //Debug.Log(cards.Count);
            heroesindex.Add(j);
        }

        for(int k = 0; k < tough/2; k++)
        {
           // Debug.Log(k);
            random = Random.Range(0, heroesindex.Count-1);
            index = heroesindex[random];
            heroesindex.RemoveAt(random);

            heroes.Add(cards[index]);
            heroes.Add(cards[index]);
        }

        random = 0;
        index = 0;

        for (int l = 0; l < tough; l++)
        {
            random = Random.Range(0, heroes.Count-1);
            Sprite spriterem = heroes[random];
            heroes.RemoveAt(random);
            Debug.Log(l);
            Instantiate(prething.gameObject, gridlaid).GetComponent<SuperHeroes>().match(spriterem, this);

        }
    }

    public bool Summon(Sprite win, SuperHeroes current)
    {
        if (this.check == null) //just started playing or clicking one after attempting two matches
        {
            this.check = win;
            if(hero1 != null)
            {
                this.hero1.thing = hero2.thing = cardback;
            }

            this.hero1 = current;
        }

        else if (this.check == win)
        {
            this.hero1.thing = null;
            current.thing = null;

            this.hero1.DefeatedHeroes();
            current.DefeatedHeroes();
            hero1 = null; 
            check = null;
            return true;
        }

        else
        {
            this.check = null;
            hero2 = current;
        }

        return false;
    }


}
