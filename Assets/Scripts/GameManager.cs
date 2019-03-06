using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Himani Raval
 * 104874756
 */

public class GameManager : MonoBehaviour
{ //manages the main card scene and pretty much the whole
    //important part of the game

        //for unity 
    public SuperHeroes prething;
    public Transform gridlaid;
    public Sprite cardback;
    public Sprite check;
    public SuperHeroes hero1, hero2;


    int s_time; //to display time
    public Text timemanager; //display time
    public int countscore = 1000; //starts at 1000
    public Text score;// = 1000;
    public FinalScreen lostORwon; //to display correct text on screen
    int something, final_time;


    public List<Sprite> cards = new List<Sprite>();
    //ALL 20 cards held here 
    //populated randomly

    private void Update() 
    {
        final_time = ((int)Time.time - s_time);
        int min = final_time / 60;
        int sec = final_time % 60;
        string strings = "";
        //This displays the time

        if(sec < 10)
        {
            strings = "Is it time for shawarma yet? " + min + " : 0" + sec;
        }

        else
        {
            strings = "Is it time for shawarma yet? " + min + " : " + sec;
        }
        timemanager.text = strings;
        /*
         * Shawarma is a reference to Tony Stark's Iron Man after he's back from
         * pushing a nuclear missile through a hold in space in the 
         * first avengers movie
         */
    }

    public void Battle(int tough) 
    //This is when user is done choosing how many heros he wants to loose against 
    {
        s_time = (int)Time.time; //timer starts
        List<int> heroesindex = new List<int>();
        //just card indices
        List<Sprite> heroes = new List<Sprite>();
        //actaul cards onn screen based on tough
      
        int random = 0, index = 0;
        //random to generate, index takes care of indices
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
            //tough/2 cuz that's how many random numbers we need
            //this will alos take care of diff cards on diff positions
            random = Random.Range(0, heroesindex.Count-1);
            index = heroesindex[random];
            heroesindex.RemoveAt(random);
            //remove so as to not repeat it
            heroes.Add(cards[index]);
            heroes.Add(cards[index]);
            //Add twice because a pair
        }

        random = 0; //reset for next use
        index = 0;


        for (int l = 0; l < tough; l++)
        {
            random = Random.Range(0, heroes.Count-1);
            Sprite spriterem = heroes[random];
            heroes.RemoveAt(random);
            Instantiate(prething.gameObject, gridlaid).GetComponent<SuperHeroes>().match(spriterem, this);
            //we are instantiaing the cards here
        }
    }

    public bool Summon(Sprite win, SuperHeroes current)
    {
        //when two cards or the first card has been clicked
        AudioManager.instance.ClickedCard(); //cardclick sound
        if (this.check == null) //just started playing or clicking one after attempting two matches
        {
            this.check = win;
            if(hero1 != null) //meaning two cards have been clicked
            {
                this.hero1.thing = hero2.thing = cardback;
                AudioManager.instance.UnMatchedCard(); //not match sounds
                countscore -= 40; //because the card is unmatched
                if(countscore <= 0)
                {
                    gameObject.SetActive(false);//take current screen away
                    hero1 = null; //disable them so we can't click them again
                    hero2 = null;
                    this.check = null;
                    AudioManager.instance.Defeated(); //because we've lost the game forever
                    lostORwon.Failed(final_time); //display appropriate text
                }
                score.text = "Score : " + countscore.ToString(); //just write score
            }
            this.hero1 = current; //reset for future references
        }

        else if (this.check == win) //if a match
        {
            AudioManager.instance.MatchedCard(); //match sound
            this.hero1.thing = null;
            current.thing = null;

            this.hero1.DefeatedHeroes(); //enable button
            current.DefeatedHeroes();
            hero1 = null; 
            check = null;
            something--;
            if(something == 0) //meaning if there are no more cards on screen
            {
                gameObject.SetActive(false); //take the surrent screen away
                AudioManager.instance.Won(); //You won
                lostORwon.Won(countscore, final_time); //display appropriate text
            }
            return true; //you won
        }

        else
        {
            //if none of the above possiblilities
            this.check = null;
            hero2 = current;
            hero1.GetComponent<Button>().enabled = true;
            hero2.GetComponent<Button>().enabled = true;
        }

        return false;
    }

}
