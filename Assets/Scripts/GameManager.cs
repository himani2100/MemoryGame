using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Himani Raval
 * 104874756
 */

public class GameManager : MonoBehaviour
{
    public SuperHeroes prething;
    public Transform gridlaid;
    public Sprite cardback;
    public Sprite check;
    public SuperHeroes hero1, hero2;
   // BattleGround setscores;

    int s_time;
    public Text timemanager;
    public int countscore = 1000; //starts at 1000
    public Text score;// = 1000;
    public FinalScreen lostORwon;
    int something, final_time;


    public List<Sprite> cards = new List<Sprite>();

    private void Update()
    {
        final_time = ((int)Time.time - s_time);
        int min = final_time / 60;
        int sec = final_time % 60;
        string strings = "";
        if(sec < 10)
        {
            strings = "Is it time for shawarma yet? " + min + " : 0" + sec;
        }

        else
        {
            strings = "Is it time for shawarma yet? " + min + " : " + sec;
        }
        timemanager.text = strings;
    }

    public void Battle(int tough)
    {
        s_time = (int)Time.time;
        List<int> heroesindex = new List<int>();
        List<Sprite> heroes = new List<Sprite>();
      
        int random = 0, index = 0;
        something = tough / 2;

        foreach (Transform thing in gridlaid)
        {
      
            Destroy(thing.gameObject);
        }

        for (int j = 0; j < cards.Count; j++)
        {
         
            heroesindex.Add(j);
        }

        for(int k = 0; k < tough/2; k++)
        {
          
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
                countscore -= 40;
                if(countscore <= 0)
                {
                    gameObject.SetActive(false);// = false;
                    hero1 = null;
                    hero2 = null;
                    this.check = null;
                    lostORwon.Failed(final_time);
                }
                score.text = "Score : " + countscore.ToString();
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
            something--;
            if(something == 0)
            {
                gameObject.SetActive(false);
                lostORwon.Won(countscore, final_time);
            }
            return true;
        }

        else
        {
            this.check = null;
            hero2 = current;
            hero1.GetComponent<Button>().enabled = true;
            hero2.GetComponent<Button>().enabled = true;
        }

        return false;
    }

}
